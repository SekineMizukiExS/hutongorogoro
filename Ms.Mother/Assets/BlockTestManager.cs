using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTestManager : MonoBehaviour
{
    public bool PlayerTurn;
    public bool EnemyTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerTurnEnded()
    {
        PlayerTurn = false;
        EnemyTurn = true;
    }
    public void EnemyTurnEnded()
    {
        EnemyTurn = false;
        PlayerTurn = true;
    }
}
