using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinStore : MonoBehaviour
{

    [SerializeField]
    private SkinDisplay display;

    private SkinManager.SkinData[] skins;

    [SerializeField]
    private SkinSeller seller;

    [SerializeField]
    private SkinSelector selector;

    [SerializeField]
    private Portefeuille currency;

    [SerializeField]
    private int current;

    [SerializeField]
    private Button prevButton, nextButton, selectButton, buyButton;

    void Start()
    {
        List<SkinManager.SkinData> storeskins = new List<SkinManager.SkinData>();
        foreach (var skin in SkinManager.Instance.Skins)
        {


            if (skin.unlocked || skin.price > 0)
            {
                storeskins.Add(skin);
            }
        }
        skins = storeskins.ToArray();
        SelectSkin(current);

        selector.OnSkinSelected += (skin) =>
        {
            SkinManager.Instance.SetSkin(skin);
        };

        seller.OnSkinBought += (skin) =>
        {
            if (currency.Currency < skin.price)
                return;

            currency.RemoveCurrency(skin.price);
            SkinManager.Instance.Unlock(skin.skin.name);
            SelectSkin(current);
        };
    }

    public void Next()
    {
        SelectSkin(current + 1);
    }

    public void Previous()
    {
        SelectSkin(current - 1);
    }

    private void SelectSkin(int index)
    {
        current = Mathf.Clamp(index, 0, skins.Length-1);
        display.SetSkin(skins[current].skin);

        if (skins[current].unlocked)
        {
            seller.Disable();
            selector.SetSkin(skins[current]);

            SetNavigationOptions(selectButton);
        }
        else
        {
            selector.Disable();
            seller.SetSkin(skins[current]);

            SetNavigationOptions(buyButton);
        }
    }

    private void SetNavigationOptions(Button newNavTarget)
    {
        Navigation navigation = prevButton.navigation;
        navigation.selectOnRight = newNavTarget;
        navigation.selectOnDown = newNavTarget;
        prevButton.navigation = navigation;

        navigation = nextButton.navigation;
        navigation.selectOnLeft = newNavTarget;
        navigation.selectOnUp = newNavTarget;
        nextButton.navigation = navigation;
    }
    
}
