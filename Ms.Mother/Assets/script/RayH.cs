using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayH : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    Ray test1;
    // Start is called before the first frame update
    void Start()
    {
        test1 = new Ray(Player.transform.position,new Vector3(0,-1.0f,0));
        Debug.Log(Player.transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        test1 = new Ray(Player.transform.position, new Vector3(0, -1.0f, 0));

        Debug.DrawRay(test1.origin, test1.direction, Color.red, 3.0f);
        if (Physics.Raycast(test1, out hit))
        {
            Debug.Log("Hit");
        }

    }
}
