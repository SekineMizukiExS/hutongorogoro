﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DataC : ScriptableObject
{
    [SerializeField]
    private string _FileName="TEST";

    [SerializeField]
    private string _tags = "Stage";

    [SerializeField]
    private string _Enemytags = "NULL";

    [NonSerialized]
    private List<GameObject> result;

    [NonSerialized]
    private List<GameObject> Enemyresult;

    [NonSerialized]
    private List<GameObject> SettingObj;

    public string SetFileName
    {
        get { return _FileName; }
#if UNITY_EDITOR
        set { _FileName = SetFileName; }
#endif
    }

    public string TagSet
    {
        get { return this._tags; }
#if UNITY_EDITOR
        set
        {
            if (value != "")
            {
                this._tags = value;
            }
            else
            {
                this._tags = "NONE";
            }
        }
#endif
    }

    public string EnemyTagSet
    {
        get { return this._Enemytags; }
#if UNITY_EDITOR
        set
        {
            if (value != "")
            {
                this._Enemytags = value;
            }
            else
            {
                this._Enemytags = "NONE";
            }
        }
#endif
    }

#if UNITY_EDITOR
    public void Copy(DataC temp)
    {
        _tags = temp._tags;
    }

    public root DataSet()
    {     
        result = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagSet));
        var temp = new root();
        var stage = new Stage();
        var Setting = new SettingData();
        //ステージ配置
        foreach(var ob in result)
        {
            var tes = ob.GetComponent<ObjectElem>();
            var trans = ob.transform;
            var Obj = new Object();
            Obj.Type = tes.Type;
            Obj.Pos = vectorToStr(trans.position);
            Obj.Rot = vectorToStr(new Vector3(0, 0, 0));
            Obj.Scale = vectorToStr(trans.localScale);
            Obj.MeshKey = tes.MeshKey;
            Obj.TexKey = tes.TexKey;
            Obj.GameTag = tes.GameTag;
            try
            {
                var obj = ob.GetComponent<PairParam>();
                Obj.PairKey = obj.PairKey;
                Obj.MovingType = obj.MovingType;
            }
            catch
            {
                //Obj.PairKey = "NULL";
                //Obj.MovingType = "NULL";
            }
            try
            {
                var Load = ob.GetComponent<LoadParam>();
                Obj.FileName = Load.LoadFileName;
                Obj.TargetPosKey = Load.TargetPosKey;
            }
            catch
            {
                //Obj.FileName = "NULL";
                //Obj.TargetPosKey = "NULL";
            }
            try
            {
                var Move = ob.GetComponent<MoveParam>();
                Obj.MoveStartVec = vectorToStr(Move.StartPoint);
                Obj.MoveEndVec = vectorToStr(Move.EndPoint);
                Obj.MovingType = Move.MovingType.ToString();
                Obj.PairKey = Move.LinkCode;
            }
            catch { }

            stage.StageObjects.Add(Obj);
        }
        //アイテム配置

        //エネミー配置
        try
        {
            Enemyresult = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            foreach (var x in Enemyresult)
            {
                var EObj = x.GetComponent<EnemyParam>();
                var transCp = x.transform;
                var EData = new EnemyData();

                EData.Type = EObj.Type;
                EData.MeshKey = EObj.MeshKey;
                EData.TexKey = EObj.TexKey;
                EData.Pos = vectorToStr(transCp.position);
                EData.Scale = vectorToStr(transCp.localScale);
                EData.Rot = vectorToStr(new Vector3(0, 0, 0));

                foreach (var MPD in EObj.Points)
                {
                    var PosData = new POINTDATA();
                    PosData.TravelingA = MPD.AfterP;
                    PosData.TravelingB = MPD.BeforeP;
                    PosData.Pos = vectorToStr(MPD.transform.position);
                    EData.MovePoint.Point.Add(PosData);
                }
                stage.EnemyDatas.Add(EData);
            }
        }
        catch
        {

        }

        try
        {
            SettingObj = new List<GameObject>(GameObject.FindGameObjectsWithTag("SettingObject"));

            foreach(var Obj in SettingObj)
            {
                var SetParam = Obj.GetComponent<SettingParam>();
                var transCp = Obj.transform;
                var SData = new SetPosData();

                SData.DataType = SetParam.Type;
                SData.PosKey = SetParam.PosKey;
                SData.PosStr = vectorToStr(transCp.position);
                Setting.posDatas.Add(SData);
            }
        }
        catch
        {

        }
        temp.Stage = stage;
        temp.settingData = Setting;
        return temp;
    }

    private string vectorToStr(Vector3 vec)
    {
        string result;
        result = vec.x.ToString() + "," + vec.y.ToString() + "," + vec.z.ToString();
        return result;
    }

#endif
}
