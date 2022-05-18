using UnityEngine.UI;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public Text currencyText;

    void Update()
    {
        currencyText.text = playerStats.Currency.ToString();
    }
}
