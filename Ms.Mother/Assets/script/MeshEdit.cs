using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEdit : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField,Range(-5.0f,5.0f)]
    private float amplitude = 0.0f;// 波の振幅（A）
    [SerializeField, Range(0.1f, 5.0f)]
    private float period = 0.0f;// 波の波長（λ）
    [SerializeField, Range(0.1f, 60.0f)]
    private float wavelength = 0.0f;// 波の周期（T）

    Ray test1;

    private Vector3 editPoint;

    MeshFilter meshFilter;
    MeshCollider meshCollider;

    bool sw = false;

    //マウス位置、どこまでの距離が変形するか
    float editDistance = 1f;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        test1 = new Ray(Player.transform.position, new Vector3(0, -1.0f, 0));
    }

    void Update()
    {
        //カメラからレイを飛ばす
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //test1 = new Ray(Player.transform.position, new Vector3(0, -1.0f, 0));

        //if (Physics.Raycast(test1, out hit))
        //{
        //    edit(hit.point);
        //}

        edit();
        if(sw)
        {
            amplitude += 1.5f*Time.deltaTime;
        }
        else
        {
            amplitude -= Time.deltaTime;
        }
        if (amplitude < 0.0f)
            amplitude = 0.0f;
        else if (amplitude > 3.0f)
        {
            amplitude = 3.0f;
            sw = !sw;
        }
    }

    private int cnt = 0;
    private float time = 0;
    void edit()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            //波源からの距離
            float x = vertices[i].x + transform.position.x;
            float z = vertices[i].z + transform.position.z;
            float r = Mathf.Sqrt((x - editPoint.x) * (x - editPoint.x) + (z - editPoint.z) * (z - editPoint.z)) * 5.0f;

            var v = vertices[i];
            v.x = x - transform.position.x;
            v.y = amplitude * Mathf.Sin(2.0f * Mathf.PI * (time / period - r / wavelength));
            v.z = z - transform.position.z;
            vertices[i] = v;
        }
        time += Time.deltaTime;
        cnt++;
        meshFilter.mesh.vertices = vertices;

        //MeshColliderにメッシュ情報を入れる
        meshCollider.sharedMesh = meshFilter.mesh;        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="InpactSphere")
        {
            editPoint = other.transform.position;
            sw = true;
            time = 0;
        }
    }
}