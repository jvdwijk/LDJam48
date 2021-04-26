using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkinManager;

public class SkinSelector : MonoBehaviour
{

    public event Action<SkinData> OnSkinSelected;

    private SkinData current;

    public void SetSkin(SkinData skin)
    {
        gameObject.SetActive(true);
        current = skin;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SelectCurrent()
    {
        OnSkinSelected?.Invoke(current);
    }
}
