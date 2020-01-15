using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EditorWindowSample : EditorWindow
{
    [MenuItem("Editor/MapExportToXML")]
    private static void Create()
    {
        // 生成
        GetWindow<EditorWindowSample>("XMLIO");
    }

    /// <summary>
    /// ScriptableObjectSampleの変数
    /// </summary>
    private DataC _sample;
    private string XML_PATH;

    private string FileName;
    private void OnGUI()
    {
        if (_sample == null)
        {
            _sample = ScriptableObject.CreateInstance<DataC>();
        }
        if(XML_PATH ==null)
        {
            XML_PATH = Application.streamingAssetsPath;
        }


        Color defaultColor = GUI.backgroundColor;
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            GUI.backgroundColor = Color.gray;
            using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Label("設定");
                //GUILayout.TextField(textField);
            }
            GUI.backgroundColor = defaultColor;

            FileName = EditorGUILayout.TextField("入出力ファイル名", FileName);

            _sample.TagSet = EditorGUILayout.TagField("検索タグ",_sample.TagSet);

            _sample.EnemyTagSet = EditorGUILayout.TagField("エネミーフィールド", _sample.EnemyTagSet);
        }

        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            GUI.backgroundColor = Color.gray;
            using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Label("パス");
            }
            GUI.backgroundColor = defaultColor;

            GUILayout.Label(XML_PATH.ToString());

            using (new GUILayout.HorizontalScope(GUI.skin.box))
            {
                GUI.backgroundColor = Color.green;
                // 読み込みボタン
                if (GUILayout.Button("読み込み"))
                {
                    EditorUtility.DisplayDialog("未実装", "CommingSoon!! よかったら自分で作ってね！", "orz");
                }
                GUI.backgroundColor = Color.magenta;
                // 書き込みボタン
                if (GUILayout.Button("書き込み"))
                {
                    bool result = true;
                    if (File.Exists(XML_PATH))
                    {
                        result = EditorUtility.DisplayDialog("Extention", "同名ファイルが存在しています。上書きしますか？", "はい", "いいえ");
                    }
                    if (result)
                    {
                        Export();
                    }
                    else
                    {
                        return;
                    }
                }
                GUI.backgroundColor = defaultColor;
            }
        }
    }

    /// <summary>
    /// アセットパス
    /// </summary>
    private string ASSET_PATH = "Assets/Resources/ScriptableObjectSample.asset";
    private void Export()
    {
      XML_PATH = Application.streamingAssetsPath +"/"+ FileName+".xml";

        // 読み込み
        DataC sample = AssetDatabase.LoadAssetAtPath<DataC>(ASSET_PATH);
        if (sample == null)
        {
            sample = ScriptableObject.CreateInstance<DataC>();
        }

        // 新規の場合は作成
        if (!AssetDatabase.Contains(_sample as UnityEngine.Object))
        {
            string directory = Path.GetDirectoryName(ASSET_PATH);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            // アセット作成
            AssetDatabase.CreateAsset(_sample, ASSET_PATH);
        }

        // コピー
        sample.Copy(_sample);



        root testData = new root();
        DataC test = sample;
        testData = test.DataSet();

        XmlUtil.Seialize<root>(XML_PATH, testData);

        // インスペクターから設定できないようにする
        _sample.hideFlags = HideFlags.NotEditable;
        // 更新通知
        EditorUtility.SetDirty(_sample);
        // 保存
        AssetDatabase.SaveAssets();
        // エディタを最新の状態にする
        AssetDatabase.Refresh();

    }

    private void Import()
    {

    }

    ///<summary>
    ///ファイルが存在しているかどうか
    /// </summary>
    //private bool CheckFile()
    //{

    //}
}
#endif