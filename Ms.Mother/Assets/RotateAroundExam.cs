using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundExam : MonoBehaviour
{

    public Vector3 rotatePoint = Vector3.zero;  //回転の中心
    public Vector3 rotateAxis = Vector3.zero;   //回転軸
    public float cubeAngle = 0f;                //回転角度

    public int Phase1 = 0;
    public int Phase2 = 0;
    public int Phase3 = 0;
    public int Phase4 = 0;
    public int Phase5 = 0;
    public int Phase6 = 0;

    public Vector3 worldPos;
    public Quaternion q;
    public Vector3 dif;

    public GameObject testObj;
    public LineRenderer testLine;

    public Vector3 ExamVec1;
    public Vector3 ExamVec2;
    public Vector3 AnswerVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateAround(rotatePoint, rotateAxis, cubeAngle);
        //transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

        AnswerVec = ExamVec1 * ExamVec2.magnitude;
    }

    //public float gizmoSize = .75f;
    //public Color gizmoColor = Color.yellow;
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = gizmoColor;
    //    Gizmos.DrawWireSphere(transform.position, gizmoSize);
    //}

    public void RotateAround(Vector3 point, Vector3 axis, float angle)
    {
        if (Phase1 == 1)
        {
            worldPos = transform.position;//自身の座標を記憶？
            testObj.transform.position = worldPos;
        }
        if (Phase2 == 1)
        {
            q = Quaternion.AngleAxis(angle, axis);//ここが謎
            testObj.transform.rotation = q;
        }
        if (Phase3 == 1)
        {
            dif = worldPos - point;//指定軸座標から自身の位置までのベクトルを作る
            testLine.SetPosition(0, point);
            testLine.SetPosition(1, worldPos);
        }
        if (Phase4 == 1)
        {
            dif = q * dif;//ベクトルにクォータニオンをかけている・・・？
            testLine.SetPosition(0, point);
            testLine.SetPosition(1, dif);
        }
        if (Phase5 == 1)
        {
            worldPos = point + dif;//上のベクターと指定軸座標を足したベクターを記憶
            testLine.SetPosition(0, point);
            testLine.SetPosition(1, worldPos);
        }
        if (Phase6 == 1)
        {
            transform.position = worldPos;//そのベクターに移動
            testObj.transform.position = worldPos;
        }
    }

}
