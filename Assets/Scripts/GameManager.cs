using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameoverui;

    void Start (){
        GameIsOver = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (playerStats.Lives <= 0 && !GameIsOver){
            EndGame();
        }
        if (Input.GetKeyDown("e")){
            EndGame();
        }
        else return;
    }
    void EndGame(){
        GameIsOver = true;
        gameoverui.SetActive(true);
    }
}
