using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValuableScoreUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI nameText, valueText;

    private int amount = 0;

    private ValuableStats valuable;

    public void Init(ValuableStats valuable)
    {
        this.valuable = valuable;
        image.sprite = valuable.icon;
        nameText.text = valuable.name;

        RefreshValueText();
    }

    public void AddOne()
    {
        amount++;
        RefreshValueText();
    }

    private void RefreshValueText()
    {
        valueText.text = $"{amount} × {valuable.price}$ = {valuable.price * amount}$";
    }
}
