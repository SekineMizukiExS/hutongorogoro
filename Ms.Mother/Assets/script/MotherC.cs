using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherC : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Huton =null;

    [SerializeField]
    float rot = 0, time = 0, interTime = 0,leftmaxRot,rightmaxRot;

    [SerializeField]
    bool ck = false;

    [SerializeField]
    private const bool CPU = false;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.clearFlug)
            return;

        time += Time.deltaTime;

        if(time>interTime)
        {
            time = 0;
            ck = !ck;
        }

        if(ck)
        {
            //Huton.transform.rotation = Quaternion.Euler(0, 0, 5);
            if (rot <= rightmaxRot)
            {
                Huton.transform.Rotate(0, 0, 2.5f);
                rot += 2.5f;
            }
            //Player.transform.Translate(0.05f, 0, 0);
        }
        else
        {
            //Huton.transform.rotation = Quaternion.Euler(0, 0, -5);
            if (rot >= leftmaxRot)
            {
                Huton.transform.Rotate(0, 0, -2.5f);
                rot += -2.5f;
            }
            //Player.transform.Translate(-0.05f, 0, 0);
        }
    }

    public void MatRotateChange(float rot)
    {
        rightmaxRot = rot;
        leftmaxRot = -rot;
    }
    public void MatRotateChange(float Lrot,float Rrot)
    {
        rightmaxRot = Rrot;
        leftmaxRot = Lrot;
    }
}
