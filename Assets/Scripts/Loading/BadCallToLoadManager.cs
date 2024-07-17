using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCallToLoadManager : MonoBehaviour
{
    public void CallLoadScene(string sceneName)
    {
        LoadManager.Instance.LoadScene(sceneName);
    }
}
