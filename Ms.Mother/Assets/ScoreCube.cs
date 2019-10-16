using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
    }
}
