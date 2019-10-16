using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiderEvents : MonoBehaviour
{
    [SerializeField]
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            GM.AddScore(100);
            Destroy(collision.gameObject);
        }
    }
}
