using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpactG : MonoBehaviour
{
    
    public GameObject mat;
    public GameObject InpactSphere;

    GameObject temps = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 100f;

            bool is_hit = Physics.Raycast(ray, out hit_info, max_distance);

            if (is_hit)
            {
                if (hit_info.transform.name == mat.name)
                {
                    //TODO: ヒットした時の処理;
                    if (temps == null)
                    {
                        Vector3 pos = hit_info.point;
                        pos.y += 10.0f;
                        temps = Instantiate(InpactSphere, pos, Quaternion.identity, transform);
                    }//Debug.Log(ray.direction);
                }
            }
        }
    }
}
