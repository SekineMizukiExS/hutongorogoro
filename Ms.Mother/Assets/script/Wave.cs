using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private Mesh mesh = null;
    [SerializeField]
    private Material material = null;

    // 媒質の長さ
    [SerializeField]
    private float LENGTH = 20.0f;
    // 自由端かどうか
    [SerializeField]
    private bool FREE_END = false;
    // シミュレーションの時間刻み
    [SerializeField]
    private float DT = 0.2f;
    // 減衰力係数
    [SerializeField]
    private float FRICTION = 2.0f;
    // 張力
    [SerializeField]
    private float TENSION = 30.0f;


    // ラインの頂点数
    const int N = 128;

    // ラインの頂点の座標
    private Vector3[] vertex = new Vector3[N];

    // ラインの頂点の速度
    float[] vertexVY = new float[N];

    // ラインの頂点に働く力
    float[] vertexFY = new float[N];

    // 単位長さあたりの質量密度
    const float DENSITY = 100.0f;

    // 初期パルスの幅
    const float PULSE_WIDTH = 0.3f;

    // 初期パルスの高さ
    const float PULSE_HEIGHT = 1.0f;

    private BoxCollider box;

    void Start()
    {
        // 頂点Xの初期値設定
        for (int i = 0; i < N; i++)
        {
            float x = i * LENGTH / N;
            vertex[i].x = x;
        }

        // 頂点Yの初期値設定（ガウス波束）
        float centerX = LENGTH / 2;
        for (int i = 0; i < N; i++)
        {

            float x = i * LENGTH / N;

            // ガウス関数
            vertex[i].y = PULSE_HEIGHT * Mathf.Exp(-(x - centerX) * (x - centerX) / (2 * PULSE_WIDTH * PULSE_WIDTH));

            // 初期速度は 0（静止状態）
            vertexVY[i] = 0.0f;
            vertexVY[N - 1] = 0.0f;
        }
    }


    void Update()
    {
        UserInput();


        // 質点間の距離
        float dx = LENGTH / N;

        // 質点1個あたりの質量
        float m = DENSITY * LENGTH / (N + 1);

        // 端以外の頂点にかかる力の計算
        for (int i = 1; i < N - 1; i++)
        {

            vertexFY[i] =
                (vertex[i + 1].y + vertex[i - 1].y - 2.0f * vertex[i].y) * TENSION / dx
                - FRICTION * vertexVY[i];
        }

        // 両端にかかる力の計算
        if (FREE_END)
        { // 自由端

            // 隣接する1個の質点からのみ力を受ける
            vertexFY[0] =
                (vertex[1].y - vertex[0].y) * TENSION / dx - FRICTION * vertexVY[0];

            vertexFY[N - 1] =
                (vertex[N - 2].y - vertex[N - 1].y) * TENSION / dx - FRICTION * vertexVY[N - 1];

        }
        else
        { //固定端

            // 壁から固定する抗力を受けるので、合力は0で動かない
            vertexFY[0] = 0.0f;
            //vertexFY[N - 1] = 0.0f;
        }

        // 位置と速度の計算
        for (int i = 0; i < N; i++)
        {

            // 頂点の速度変化の計算
            vertexVY[i] += vertexFY[i] / m * DT;

            // 頂点の座標変化の計算
            vertex[i].y += vertexVY[i] * DT;
        }

        foreach (var vec in vertex)
        {
            Graphics.DrawMesh(mesh, vec, Quaternion.identity, material, 0);
        }
    }


    private void UserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vertexVY[N/2] = -5.0f;
        }else if (Input.GetMouseButtonDown(1))
        {
            vertexVY[N/2] = 5.0f;
        }
    }

} // class WaveTest