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


    public GameObject clearText;
    public GameObject overText;
    public GameObject Futon;
    public bool clearFlug;
    public bool overFlug;

    public int score = 0;
    public float time = 0;

    public MotherC motherC;
    public PlayerC playerC;

    // Start is called before the first frame update
    void Start()
    {
        if (!motherC)
        {
            motherC = GameObject.Find("mat").GetComponent<MotherC>();
        }
        if (!playerC)
        {
            playerC = GameObject.Find("Player").GetComponent<PlayerC>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(limitTime < time)
        {
            GameClearOn();
        }
        else
        {
            time += 1 * Time.deltaTime;
            timeText.text = "Time:" + ((int)(limitTime - time)).ToString("D3");
        }
        Futon.GetComponent<FutonVA>().SendLimetTime(limitTime - time);
    }

    public void AddScore(int addscore)
    {
        score += addscore;
        scoreText.text = "Score:" + score.ToString("D5");
    }

    //くりあ後の処理
    public void GameClearEvent()
    {
        motherC.MatRotateChange(0);
    }

    public void GameClearOn()
    {
        if (!clearFlug && !overFlug)
        {
            clearFlug = true;
            clearText.SetActive(true);
            GameClearEvent();
        }
    }
    //ゲームオーバー受け取り
    public void GameOverOn()
    {
        if (!clearFlug && !overFlug)
        {
            overFlug = true;
            overText.SetActive(true);
        }
    }
}
