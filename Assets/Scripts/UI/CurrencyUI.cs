using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField]
    private Portefeuille currency;

    [SerializeField]
    private TMPro.TextMeshProUGUI currencyText;

    private void Start()
    {
        SetCurrencyText(currency.Currency);
        currency.OnCurrencyChange += SetCurrencyText;
    }

    private void SetCurrencyText(int amount)
    {
        currencyText.text = $"{amount} $";
    }
}
