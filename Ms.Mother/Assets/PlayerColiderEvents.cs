using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiderEvents : MonoBehaviour
{
    [SerializeField]
    GameManager GM;

    AudioSource m_AS;
    [SerializeField]
    AudioClip[] m_AC;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -20)
        {
            GM.GameOverOn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            GM.AddScore(100);
            PlaySound(1);
            Destroy(collision.gameObject);
        }
    }

    public void PlaySound(int n)
    {
        m_AS.PlayOneShot(m_AC[n]);
    }
    
}
