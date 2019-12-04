using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateAround : MonoBehaviour
{

    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸
    float cubeAngle = 0f;                //回転角度

    public LayerMask blockLayer;
    public BlockTestManager BTM;

    float cubeSizeHalf;                  //キューブの大きさの半分
    bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    void Start()
    {
        cubeSizeHalf = transform.localScale.x / 2f;
    }

    void Update()
    {
        if (BTM.EnemyTurn)
        {
            
            //Debug.Log("hol:" + Input.GetAxis("Horizontal"));
            //回転中は入力を受け付けない
            if (isRotate)
                return;

            int i = Random.Range(0,4);
            if (i == 1)
            {
                rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);

                if (!Physics.Raycast(transform.position, new Vector3(1, 0, 0), 1, blockLayer))
                {
                    rotateAxis = new Vector3(0, 0, -1);
                }
                else
                {
                    Debug.Log("ng");
                    BTM.EnemyTurnEnded();
                    return;
                }
            }
            else if (i == 2)
            {
                rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
                if (!Physics.Raycast(transform.position, new Vector3(-1, 0, 0), 1, blockLayer))
                {
                    rotateAxis = new Vector3(0, 0, 1);
                }
                else
                {
                    Debug.Log("ng");
                    BTM.EnemyTurnEnded();
                    return;
                }
            }
            else if (i == 3)
            {
                rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, 1), 1, blockLayer))
                {
                    rotateAxis = new Vector3(1, 0, 0);
                }
                else
                {
                    Debug.Log("ng");
                    BTM.EnemyTurnEnded();
                    return;
                }
            }
            else if (i == 0)
            {
                rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, -1), 1, blockLayer))
                {
                    rotateAxis = new Vector3(-1, 0, 0);
                }
                else
                {
                    Debug.Log("ng");
                    BTM.EnemyTurnEnded();
                    return;
                }
            }
            // 入力がない時はコルーチンを呼び出さないようにする
            if (rotatePoint == Vector3.zero)
                return;
            StartCoroutine(MoveCube());
        }
    }

    IEnumerator MoveCube()
    {
        //回転中のフラグを立てる
        isRotate = true;

        //回転処理
        float sumAngle = 0f; //angleの合計を保存
        while (sumAngle < 90f)
        {
            cubeAngle = 15f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 180f)
            {
                cubeAngle -= sumAngle - 180f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

            yield return null;
        }

        //回転中のフラグを倒す
        isRotate = false;
        rotatePoint = Vector3.zero;
        rotateAxis = Vector3.zero;
        BTM.EnemyTurnEnded();
        //PlColEve.PlaySound(0);

        yield break;
    }
}

