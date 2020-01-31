using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class root
{
    public Stage Stage = new Stage();
    public SettingData settingData = new SettingData();
}

[Serializable]
public class SettingData
{
    public List<SetPosData> posDatas = new List<SetPosData>();
}

//開始位置などのポジションデータ群
[Serializable]
public class SetPosData
{
    [System.Xml.Serialization.XmlAttribute("Type")]
    public string DataType;

    [System.Xml.Serialization.XmlAttribute("PosKey")]
    public string PosKey;

    [System.Xml.Serialization.XmlAttribute("Position")]
    public string PosStr;
}

[Serializable]
public class Stage
{
   public List<Object> StageObjects = new List<Object>();
    public List<EnemyData> EnemyDatas = new List<EnemyData>();
}

[Serializable]
public class Object
{
    [System.Xml.Serialization.XmlAttribute("Type")]
    public string Type;
    [System.Xml.Serialization.XmlAttribute("Tag")]
    public string GameTag;
    [System.Xml.Serialization.XmlAttribute("Pos")]
    public string Pos;
    [System.Xml.Serialization.XmlAttribute("Scale")]
    public string Scale;
    [System.Xml.Serialization.XmlAttribute("Rot")]
    public string Rot;
    [System.Xml.Serialization.XmlAttribute("MeshKey")]
    public string MeshKey;
    [System.Xml.Serialization.XmlAttribute("TexKey")]
    public string TexKey;
    [System.Xml.Serialization.XmlAttribute("LoadMapFile")]
    public string FileName;
    [System.Xml.Serialization.XmlAttribute("TargetPosKey")]
    public string TargetPosKey;
    [System.Xml.Serialization.XmlAttribute("LINKCODE")]
    public string PairKey;
    [System.Xml.Serialization.XmlAttribute("MovingType")]
    public string MovingType;
    [System.Xml.Serialization.XmlAttribute("MoveStartVec")]
    public string MoveStartVec;
    [System.Xml.Serialization.XmlAttribute("MoveEndVec")]
    public string MoveEndVec;
}

//EnemyXML
[Serializable]
public class EnemyData :Object
{
    public OParam ObjParam = new OParam();
    public MPoint MovePoint = new MPoint();
}

[Serializable]
public class OParam
{
    [System.Xml.Serialization.XmlAttribute("State")]
    public string State = "Wait";
}

[Serializable]
public class MPoint
{
    public List<POINTDATA> Point = new List<POINTDATA>();
}

[Serializable]
public class POINTDATA
{
    [System.Xml.Serialization.XmlAttribute("Pos")]
    public string Pos;
    [System.Xml.Serialization.XmlAttribute("TravelingB")]
    public string TravelingB;
    [System.Xml.Serialization.XmlAttribute("TravelingA")]
    public string TravelingA;
}

[Serializable]
public class XmlUtil: ScriptableObject
{
#if UNITY_EDITOR
    // シリアライズ
    public static void Seialize<T>(string filename, T data)
    {
        try
        {
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, data);
            }
        }
        catch
        {
            //Debug.Log("同名ファイルが存在している");
        }
    }

    // デシリアライズ
    public static T Deserialize<T>(string filename)
    {
        using (var stream = new FileStream(filename, FileMode.Open))
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
#endif
}
