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
    private Image boop;

    [SerializeField]
    private Sprite redBoop, greenBoop;

    [SerializeField]
    private RectTransform levelContainer;

    [SerializeField]
    private TMPro.TextMeshProUGUI priceText;

    private UpgradeManager manager;

    private List<Image> boops = new List<Image>();

    private void Start()
    {
        manager = GameObject.Find("UpgradesManager")?.GetComponent<UpgradeManager>();

        if (manager == null)
            return;

        buyButton.onClick.AddListener(Buy);

        InitLevels();
        SetPrice();
        CheckIfAvailible();
        RefreshLevels();
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

        int unlockedAmount = manager.FindUpgrade(type).GetUnlockedUpgradeAmount();
        PlayerPrefs.SetInt("UpgradeType" + type.ToString(), (int) type);
        PlayerPrefs.SetInt("UpgradeLevel" + type.ToString(), unlockedAmount);

        SetPrice();
        RefreshLevels();
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

    private void InitLevels()
    {
        var upgradeValues = manager.FindUpgrade(type).UpgradeValues;
        for (int i = 0; i < upgradeValues.Count; i++)
        {
            Image currentBoop = Instantiate(boop);
            boops.Add(currentBoop);
            currentBoop.transform.SetParent(levelContainer);
            currentBoop.transform.SetAsFirstSibling();
            currentBoop.transform.localScale = Vector3.one;
        }
    }

    private void RefreshLevels()
    {
        var upgradeValues = manager.FindUpgrade(type).UpgradeValues;
        for (int i = 0; i < upgradeValues.Count; i++)
        {
            Sprite currentBoopColor = upgradeValues[i].unlocked ? greenBoop : redBoop;
            boops[i].sprite = currentBoopColor;
        }
    }

}
