using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOneVictoryRoyaleRegisterer : MonoBehaviour
{
    public const string VICTORY_PLAYER_PREF_ID = "number one victory royale";

    void Start()
    {
        PlayerPrefs.SetInt(VICTORY_PLAYER_PREF_ID, 1);   
    }
}
