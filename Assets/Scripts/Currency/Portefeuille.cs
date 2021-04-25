using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portefeuille : MonoBehaviour
{
    private const int STARTING_CURRENCY = 0;
    private const string CURRENCY_PLAYER_PREF_ID = "currency";

    private int currentCurrency = 0;

    public event Action<int> OnCurrencyChange;

    public int Currency => currentCurrency;

    private void Awake()
    {
        currentCurrency = PlayerPrefs.GetInt(CURRENCY_PLAYER_PREF_ID, STARTING_CURRENCY);
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        OnCurrencyChange?.Invoke(currentCurrency);
    }

    public void RemoveCurrency(int amout)
    {
        AddCurrency(-amout);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(CURRENCY_PLAYER_PREF_ID, Currency);
    }

}
