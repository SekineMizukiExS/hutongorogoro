using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [SerializeField]
    GameObject Body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(0.2f, 0, 0);
            Body.transform.Rotate(0,90,0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-0.2f, 0, 0);
            Body.transform.Rotate(0, -90, 0);
        }

    }
}
