using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkinManager;

public class SkinSeller : MonoBehaviour
{

    [SerializeField]
    private TMPro.TextMeshProUGUI price;

    private SkinData currentSkin;

    public event Action<SkinData> OnSkinBought;

    public void SetSkin(SkinData skin)
    {
        gameObject.SetActive(true);
        currentSkin = skin;
        price.text = $"{skin.price} $";
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void BuyCurrent()
    {
        OnSkinBought?.Invoke(currentSkin);
    }
}
