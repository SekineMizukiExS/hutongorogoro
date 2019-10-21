using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [SerializeField]
    GameObject Body;
    [SerializeField]
    GameObject HutonObj;
    Vector3 HutonRight;

    Rigidbody dd;

    // Start is called before the first frame update
    void Start()
    {
        dd = Body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velo;
        velo = dd.velocity;


        if (Input.GetKeyDown(KeyCode.D))
        {
            HutonRight = HutonObj.transform.right;
            transform.Translate(0.2f * HutonRight);
            Body.transform.Rotate(0,90,0);
            velo.y = 0.0f;
            dd.velocity=velo;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            HutonRight = HutonObj.transform.right;
            transform.Translate(-0.2f * HutonRight);
            Body.transform.Rotate(0, -90, 0);
            velo.y = 0.0f;
            dd.velocity = velo;
        }

    }
}
