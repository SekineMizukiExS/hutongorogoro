using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pirania : MonoBehaviour
{
    float rot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rot <= 180)
        {
            transform.Rotate(0.5f, 0, 0);
            rot += 0.5f;
        }
    }
}
