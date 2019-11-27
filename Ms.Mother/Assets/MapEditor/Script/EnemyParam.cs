using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam : MonoBehaviour
{
    [SerializeField]
    public string Type;
    [SerializeField]
    public string MeshKey;
    [SerializeField]
    public string TexKey;
    [SerializeField]
    public string State = "Wait";
    [SerializeField]
    public List<MovePointParam> Points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
