using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timeText;
    [SerializeField]
    float limitTime;

    public bool clearFlug;

    public int score = 0;
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(limitTime < time)
        {
            clearFlug = true;
        }
        else
        {
            time += 1 * Time.deltaTime;
            timeText.text = "Time:" + ((int)(limitTime - time)).ToString("D3");
        }
    }

    public void AddScore(int addscore)
    {
        score += addscore;
        scoreText.text = "Score:" + score.ToString("D5");
    }
}
