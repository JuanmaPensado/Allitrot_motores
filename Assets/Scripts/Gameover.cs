
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text roundsText;

    void OnEnable(){
        roundsText.text = playerStats.Rounds.ToString();
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
