# Name-Based Material Matcher（名前ベースのマテリアルマッチャー）

Name-Based Material Matcherは、Skinned Mesh Rendererのマテリアルを名前に基づいてマッチングし置換するUnityエディタツールです。このツールは、VRMアセット管理や他のマテリアル同期が必要なシナリオで特に有用です。

## 特徴

- 使いやすいUnityエディタウィンドウ
- マテリアル名に基づくマッチング
- 複数の検索フォルダをサポート
- .matと.assetファイル拡張子の互換性オプション
- Skinned Mesh Rendererに対応

## インストール方法

1. [リリース](https://github.com/yourusername/name-based-material-matcher/releases)ページにアクセスします。
2. 最新の`Name-Based-Material-Matcher.unitypackage`ファイルをダウンロードします。
3. Unityプロジェクトを開きます。
4. Assets > Import Package > Custom Packageに移動します。
5. ダウンロードした.unitypackageファイルを選択し、すべてのアセットをインポートします。

## 使用方法

1. Unityで、Window > Kurogane > Name-Based Material Matcherを選択してツールウィンドウを開きます。
2. 「Target Renderer」フィールドに対象のSkinned Mesh Rendererをアサインします。
3. 「Add Search Folder」をクリックし、プロジェクトウィンドウからフォルダをドラッグして検索フォルダを追加します。
4. .matと.asset拡張子に関係なくマテリアルをマッチングしたい場合は、「Allow .mat/.asset Interchange」をオンにします。
5. 「Replace Materials」をクリックして、マテリアルのマッチングと置換を実行します。

## 貢献

貢献は歓迎します！プルリクエストを自由に提出してください。

## ライセンス

このプロジェクトはMITライセンスの下で公開されています。詳細は[LICENSE](LICENSE)ファイルをご覧ください。

