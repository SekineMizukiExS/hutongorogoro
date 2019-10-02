using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherC : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Huton;

    [SerializeField]
    float rot = 0,time = 0;

    [SerializeField]
    bool ck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>0.5f)
        {
            time = 0;
            ck = !ck;
        }

        if(ck)
        {
            //Huton.transform.rotation = Quaternion.Euler(0, 0, 5);
            if (rot <= 45)
            {
                Huton.transform.Rotate(0, 0, 2.5f);
                rot += 2.5f;
            }
            //Player.transform.Translate(0.05f, 0, 0);
        }
        else
        {
            //Huton.transform.rotation = Quaternion.Euler(0, 0, -5);
            if (rot >= -45)
            {
                Huton.transform.Rotate(0, 0, -2.5f);
                rot += -2.5f;
            }
            //Player.transform.Translate(-0.05f, 0, 0);
        }
    }
}
