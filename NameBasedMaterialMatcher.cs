using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class NameBasedMaterialMatcher : EditorWindow
{
    private SkinnedMeshRenderer targetRenderer;
    private List<DefaultAsset> searchFolders = new List<DefaultAsset>();
    private bool allowMatAssetInterchange = true;
    private Vector2 scrollPosition;

    [MenuItem("Window/Kurogane/Name-Based Material Matcher")]
    public static void ShowWindow()
    {
        GetWindow<NameBasedMaterialMatcher>("Name-Based Material Matcher");
    }

    private void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        GUILayout.Label("Material Replacement Tool", EditorStyles.boldLabel);

        targetRenderer = EditorGUILayout.ObjectField("Target Renderer", targetRenderer, typeof(SkinnedMeshRenderer), true) as SkinnedMeshRenderer;

        EditorGUILayout.Space();

        GUILayout.Label("Search Folders", EditorStyles.boldLabel);
        for (int i = 0; i < searchFolders.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            
            DefaultAsset newFolder = EditorGUILayout.ObjectField(searchFolders[i], typeof(DefaultAsset), false) as DefaultAsset;
            if (newFolder != searchFolders[i])
            {
                if (newFolder == null || AssetDatabase.IsValidFolder(AssetDatabase.GetAssetPath(newFolder)))
                {
                    searchFolders[i] = newFolder;
                }
                else
                {
                    EditorUtility.DisplayDialog("Invalid Selection", "Please select a folder.", "OK");
                }
            }

            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                searchFolders.RemoveAt(i);
                GUIUtility.ExitGUI();
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Search Folder"))
        {
            searchFolders.Add(null);
        }

        EditorGUILayout.Space();

        allowMatAssetInterchange = EditorGUILayout.Toggle("Allow .mat/.asset Interchange", allowMatAssetInterchange);

        EditorGUILayout.Space();

        if (GUILayout.Button("Replace Materials"))
        {
            ReplaceMaterials();
        }

        EditorGUILayout.EndScrollView();
    }

    private void ReplaceMaterials()
    {
        if (targetRenderer == null)
        {
            EditorUtility.DisplayDialog("Error", "Please assign a Skinned Mesh Renderer.", "OK");
            return;
        }

        if (searchFolders.Count == 0 || searchFolders.All(f => f == null))
        {
            EditorUtility.DisplayDialog("Error", "Please add at least one valid search folder.", "OK");
            return;
        }

        Material[] currentMaterials = targetRenderer.sharedMaterials;
        Material[] newMaterials = new Material[currentMaterials.Length];

        for (int i = 0; i < currentMaterials.Length; i++)
        {
            Material currentMaterial = currentMaterials[i];
            Material replacementMaterial = FindReplacementMaterial(currentMaterial.name);

            if (replacementMaterial != null)
            {
                newMaterials[i] = replacementMaterial;
                Debug.Log($"Replaced material: {currentMaterial.name} with {replacementMaterial.name}");
            }
            else
            {
                newMaterials[i] = currentMaterial;
                Debug.LogWarning($"Could not find replacement for material: {currentMaterial.name}");
            }
        }

        Undo.RecordObject(targetRenderer, "Replace Materials");
        targetRenderer.sharedMaterials = newMaterials;
        EditorUtility.SetDirty(targetRenderer);
    }

    private Material FindReplacementMaterial(string materialName)
    {
        foreach (var folder in searchFolders.Where(f => f != null))
        {
            string folderPath = AssetDatabase.GetAssetPath(folder);
            string[] guids = AssetDatabase.FindAssets("t:Material", new[] { folderPath });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Material material = AssetDatabase.LoadAssetAtPath<Material>(path);
                
                if (material != null)
                {
                    if (material.name == materialName)
                    {
                        return material;
                    }
                    
                    if (allowMatAssetInterchange)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                        if (fileNameWithoutExtension == materialName)
                        {
                            return material;
                        }
                    }
                }
            }
        }
        return null;
    }
}