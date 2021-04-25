using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portefeuille : MonoBehaviour
{
    private const int STARTING_CURRENCY = 0;
    private const string CURRENCY_PLAYER_PREF_ID = "currency";

    private int currentCurrency = 0;

    private void Start()
    {
        currentCurrency = PlayerPrefs.GetInt(CURRENCY_PLAYER_PREF_ID, STARTING_CURRENCY);
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount; 
    }

    public void RemoveCurrency(int amout)
    {
        currentCurrency -= amout;
    }

    private void OnDisable()
    {
        PlayerPrefs.DeleteKey(CURRENCY_PLAYER_PREF_ID);
    }

}
