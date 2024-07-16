using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooleanPlayerprefSetting : MonoBehaviour
{

    public const int PLAYERPREF_BOOL_TRUE = 1;
    public const int PLAYERPREF_BOOL_FALSE = 0;

    [SerializeField]
    private string PlayerPrefKey;//show list of player pref keys instead of this

    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private bool defaultValue;

    private void Start() {

        if (!PlayerPrefs.HasKey(PlayerPrefKey))
            PlayerPrefs.SetInt(PlayerPrefKey, ToIntValue(defaultValue));
        toggle.isOn = getPref();
        toggle.onValueChanged.AddListener(SetPref);
    }

    public void SetPref(bool value){
        var intValue = ToIntValue(value);
        PlayerPrefs.SetInt(PlayerPrefKey, intValue);
    }

    private int ToIntValue(bool value) {
        return value ? PLAYERPREF_BOOL_TRUE : PLAYERPREF_BOOL_FALSE;
    }

    private bool getPref(){
        var intValue = PlayerPrefs.GetInt(PlayerPrefKey, ToIntValue(defaultValue));
        return intValue != PLAYERPREF_BOOL_FALSE;
    }

}
