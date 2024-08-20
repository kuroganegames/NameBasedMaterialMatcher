# Name-Based Material Matcher

Name-Based Material Matcher is a Unity editor tool designed to simplify the process of matching and replacing materials in Skinned Mesh Renderers based on material names. This tool is particularly useful for VRM asset management and other scenarios where material synchronization is needed.

Name-Based Material Matcherは、Skinned Mesh Rendererのマテリアルを名前に基づいてマッチングし置換するUnityエディタツールです。このツールは、VRMアセット管理や他のマテリアル同期が必要なシナリオで特に有用です。

[日本語のREADMEはこちら](README_JP.md)

## Features

- Easy-to-use Unity editor window
- Matches materials based on their names
- Supports multiple search folders
- Option to allow .mat/.asset file extension interchangeability
- Works with Skinned Mesh Renderers

## Installation

1. Go to the [Releases]([https://github.com/yourusername/name-based-material-matcher/releases](https://github.com/kuroganegames/NameBasedMaterialMatcher/releases)) page.
2. Download the latest `Name-Based-Material-Matcher.unitypackage` file.
3. Open your Unity project.
4. Go to Assets > Import Package > Custom Package.
5. Select the downloaded .unitypackage file and import all assets.

## Usage

1. In Unity, go to Window > Kurogane > Name-Based Material Matcher to open the tool window.
2. Assign your target Skinned Mesh Renderer to the "Target Renderer" field.
3. Add search folders by clicking "Add Search Folder" and dragging folders from your Project window.
4. Toggle "Allow .mat/.asset Interchange" if you want to match materials regardless of these file extensions.
5. Click "Replace Materials" to perform the material matching and replacement.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

