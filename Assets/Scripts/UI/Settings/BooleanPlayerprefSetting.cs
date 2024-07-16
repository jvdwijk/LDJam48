using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanPlayerprefSetting : MonoBehaviour
{

    [SerializeField]
    private string PlayerPrefKey;//show list of player pref keys instead of this

    public void SetPref(bool value){
        var intValue = value ? 1 : 0;
        PlayerPrefs.SetInt(PlayerPrefKey, intValue);
    }


}
