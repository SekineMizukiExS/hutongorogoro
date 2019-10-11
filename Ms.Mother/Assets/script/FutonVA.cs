using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutonVA : MonoBehaviour
{
    [SerializeField]
    private MeshFilter _filter;
    [SerializeField]
    private MeshCollider _collider;

    private const float Max = 0.1f, Min = -0.1f;

    float key = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _filter = gameObject.GetComponent<MeshFilter>();
        _collider = gameObject.GetComponent<MeshCollider>();
    }

    private int cnt = 0;
    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = _filter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            var v = vertices[i];
            v.y = Mathf.Sin((i + cnt) / 20.0f);
            vertices[i] = v;
        }
        cnt++;
        _filter.mesh.vertices = vertices;
        _filter.mesh.RecalculateBounds();
        _collider.sharedMesh = null;
        _collider.sharedMesh = _filter.mesh;
    }
}
