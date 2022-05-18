using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public static  int Lives;
    public int startlives = 20;

    public static int Currency;
    public int startCurrency = 400;
    void Start()
    {
        Lives = startlives; 
        Currency = startCurrency;
    }
}
