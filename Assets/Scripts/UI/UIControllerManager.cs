using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControllerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject firstSelected;

    private void Awake()
    {
        firstSelected = EventSystem.current.currentSelectedGameObject;
    }

    public void SetSelectedUIObject(GameObject newSelected)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newSelected);
    }
}
