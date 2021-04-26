using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUnlock : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(PlayerPrefs.GetInt(NumberOneVictoryRoyaleRegisterer.VICTORY_PLAYER_PREF_ID, -0) > 0);
    }
}
