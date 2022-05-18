
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        livesText.text = Mathf.Clamp(playerStats.Lives, 0f, Mathf.Infinity).ToString();
    }
}
