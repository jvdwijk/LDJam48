using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSkinChanger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer head, tail;

    [SerializeField]
    private BodyManager body;

    [SerializeField]
    private Skin current;

    private void Start()
    {
        if(SkinManager.Instance == null)
        {
            SetSkin(current);
            return;
        }

        body.OnMiddlePartAdded += SetBodypart;

        SetSkin(SkinManager.Instance.Current, false);
        SkinManager.Instance.OnSkinChange += SetSkin;
    }

    private void OnDisable()
    {
        SkinManager.Instance.OnSkinChange -= SetSkin;
    }

    private void SetSkin(Skin skin)
    {
        SetSkin(skin, true);
    }

    private void SetSkin(Skin skin, bool loop)
    {
        current = skin;
        head.sprite = current.Head;
        tail.sprite = current.Tail;

        if (loop)
        {
            foreach (var part in body.MiddleParts)
            {
                SetBodypart(part.gameObject);
            }
        }
    }

    private void SetBodypart(GameObject part)
    {
        part.GetComponentInChildren<SpriteRenderer>().sprite = current.Body;
    }

}
