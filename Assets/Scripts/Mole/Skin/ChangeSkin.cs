using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public SkinChance[] skins;

    private void Start()
    {
        float totalChance = 0;
        for (int i = 0; i < skins.Length; i++)
        {
            totalChance += skins[i].chance;
        }
        float currentChance = 0;
        float random = Random.value * totalChance;
        for (int i = 0; i < skins.Length; i++)
        {
            currentChance += skins[i].chance;
            if (random < currentChance)
            {
                spriteRenderer.sprite = skins[i].sprite;
                return;
            }
        }
    }
}
