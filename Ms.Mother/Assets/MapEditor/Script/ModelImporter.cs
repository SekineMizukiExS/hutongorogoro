using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public sealed class ModelPostprocessor : AssetPostprocessor
{
    private void OnPostprocessModel(GameObject go)
    {
        var assetPath = assetImporter.assetPath;
        var directory = Path.GetDirectoryName(assetPath);

        var name = Path.GetFileNameWithoutExtension(assetPath);

        AddDataSet(go.transform);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void AddDataSet(Transform game)
    {
        game.transform.gameObject.tag = "Stage".ToString();
        game.gameObject.AddComponent<ObjectElem>().Type = "FixedObject";
    }
}
#endif