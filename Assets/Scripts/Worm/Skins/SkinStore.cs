using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int current;

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
        }
        else
        {
            selector.Disable();
            seller.SetSkin(skins[current]);
        }
    }
    
}
