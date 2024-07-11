using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI depthText, healthText;

    [SerializeField]
    private Health health;

    private void Update()
    {
        depthText.text = Mathf.RoundToInt(-health.transform.position.y).ToString();
        healthText.text = Mathf.RoundToInt(health.Value).ToString();
    }
}
