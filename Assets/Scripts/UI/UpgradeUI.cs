using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{

    [SerializeField]
    private UpgradeType type;

    [SerializeField]
    private Portefeuille currency;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private TMPro.TextMeshProUGUI priceText;

    private UpgradeManager manager;

    private void Start()
    {
        manager = GameObject.Find("UpgradesManager").GetComponent<UpgradeManager>();

        buyButton.onClick.AddListener(Buy);

        SetPrice();
        CheckIfAvailible();
    }

    public void Buy()
    {
        var next = manager.FindUpgrade(type).GetHighest(true);

        if(next.cost > currency.Currency)
        {
            return;
        }

        currency.RemoveCurrency(next.cost);
        next.unlocked = true;

        SetPrice();
        CheckIfAvailible();
    }

    private void CheckIfAvailible()
    {
        if (manager.FindUpgrade(type).GetHighest(true) == null)
        {
            buyButton.interactable = false;
        }
    }

    private void SetPrice()
    {
        var next = manager.FindUpgrade(type).GetHighest(true);
        if(next == null)
        {
            priceText.text = $"maxed out";
            return;
        }
        priceText.text = $"{next.cost} $";
    }

}
