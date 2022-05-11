using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameended = false;
    void Update()
    {
        if (playerStats.Lives <= 0 && !gameended){
            EndGame();
        }
        else return;
    }
    void EndGame(){
        gameended = true;
        Debug.Log("GAME OVER!!!");
    }
}
