using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public string levelToLoad = "Main";
    public GameObject UI;

    public void Play(){
        SceneManager.LoadScene(levelToLoad);
    }
    public void Exit(){
        Debug.Log("X");
        Application.Quit();
    }
    public void Controls(){
        UI.SetActive(!UI.activeSelf);
    }
}
