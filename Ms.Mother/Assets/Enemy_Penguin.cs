using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Penguin : MonoBehaviour
{
    [SerializeField]
    float m_spead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * m_spead * Time.deltaTime ;

        if(transform.position.z >= 20)
        {
            Destroy(gameObject);
        }
    }
}
