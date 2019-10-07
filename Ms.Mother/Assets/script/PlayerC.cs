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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            HutonRight = HutonObj.transform.right;
            transform.Translate(0.2f * HutonRight);
            Body.transform.Rotate(0,90,0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            HutonRight = HutonObj.transform.right;
            transform.Translate(-0.2f * HutonRight);
            Body.transform.Rotate(0, -90, 0);
        }

    }
}
