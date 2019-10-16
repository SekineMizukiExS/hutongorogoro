using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject scoreObject;
    [SerializeField]
    Vector3[] spawnField = new Vector3[2];
    [SerializeField]
    GameObject mat;
    [SerializeField]
    float respawntime = 0;

    float m_respawnWait = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_respawnWait += 0.1f;
        if (m_respawnWait > respawntime) {
            Vector3 tempPos = new Vector3(0,0,0);
            tempPos.x = (1 + mat.transform.up.x) * Random.Range(spawnField[0].x, spawnField[1].x);
            tempPos.y = 3 + mat.transform.up.y;
            tempPos.z = (1 + mat.transform.up.z) * Random.Range(spawnField[0].z, spawnField[1].z);
            GameObject tempScore = Instantiate(scoreObject, tempPos,mat.transform.rotation,mat.transform);
            //tempScore.transform.parent = mat.transform;
            m_respawnWait = 0;
        }
    }
}
