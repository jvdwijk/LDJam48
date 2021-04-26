using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinDisplay : MonoBehaviour
{

    [SerializeField]
    private Image head;

    [SerializeField]
    private Image[] body;

    [SerializeField]
    private Image tail;

    public void SetSkin(Skin skin)
    {
        head.sprite = skin.Head;

        for (int i = 0; i < body.Length; i++)
        {
            body[i].sprite = skin.Body;
        }

        tail.sprite = skin.Tail;
    }
}
