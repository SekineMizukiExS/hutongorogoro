using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutonVA : MonoBehaviour
{
    [SerializeField]
    private MeshFilter _filter;
    [SerializeField]
    private MeshCollider _collider;
    [SerializeField]
    private bool move_sw = false,wave_sw = false;
    [SerializeField]
    private float limet = 0;
    private const float Max = 0.1f, Min = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _filter = gameObject.GetComponent<MeshFilter>();
        _collider = gameObject.GetComponent<MeshCollider>();
    }

    private int cnt = 0;

    float palse = 0.0f, time = 0;
    // Update is called once per frame
    void Update()
    {
        //生存時間で発生させる
        if (limet < 30)
        {
            Move();
        }
        if(limet<20)
        {
            WaveF(wave_sw);
        }
    }

    public void SendLimetTime(float lime)
    {
        limet = lime;
    }

    void WaveF(bool ss)
    {
        if (ss)
        {
            palse += Time.deltaTime*0.05f;
        }
        else
        {
            palse -= Time.deltaTime * 0.05f;
        }

        if (palse > 1.0f)
        {
            palse = 1.0f;
            wave_sw = !wave_sw;
        }
        else if (palse < -1.0f)
        {
            palse = -1.0f;
            wave_sw = !wave_sw;
        }
        Vector3[] vertices = _filter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            var v = vertices[i];
            v.y = palse * Mathf.Sin((i + cnt) / 20.0f);
            vertices[i] = v;
        }
        cnt++;
        _filter.mesh.vertices = vertices;
        _filter.mesh.RecalculateBounds();
        _collider.sharedMesh = null;
        _collider.sharedMesh = _filter.mesh;
    }

    float tlen = 0,t=0;

    private void Move()
    {
        time += Time.deltaTime;

        if (time > 3.0f)
        {
            time = 0;
            move_sw = !move_sw;
        }

        if (move_sw)
        {
            if (t < 2.0f)
            {
                transform.localPosition=transform.localPosition+new Vector3(0.025f, 0, 0);
                t += 0.05f;
            }
        }
        else
        {
            if (t > -2.0f)
            {
                transform.localPosition = transform.localPosition + new Vector3(-0.025f, 0, 0);
                t -= 0.05f;
            }
        }
    }
}
