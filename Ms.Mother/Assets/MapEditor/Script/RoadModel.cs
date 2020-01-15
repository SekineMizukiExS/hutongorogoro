using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class RoadModel : EditorWindow
{
    [MenuItem("Editor/RoadModel")]
    private static void Create()
    {
        // 生成
        GetWindow<RoadModel>("RoadMD");
    }

    private void OnGUI()
    {
        using (new GUILayout.HorizontalScope(GUI.skin.box))
        {
            if(GUILayout.Button("読込"))
            {
                Test();
            }
        }
    }

    private void Test()
    {
        GameObject T = new GameObject();
        string name = "target";
        string outputPath = "Assets/MapEditor/Prefab.prefab";

        GameObject gameObject = EditorUtility.CreateGameObjectWithHideFlags(name, HideFlags.HideInInspector);

        GameObject result = PrefabUtility.SaveAsPrefabAsset(gameObject,outputPath);
        PrefabUtility.RevertAddedGameObject(gameObject, InteractionMode.UserAction);
        Editor.DestroyImmediate(gameObject);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif