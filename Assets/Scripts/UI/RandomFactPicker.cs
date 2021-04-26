using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomFactPicker : MonoBehaviour
{
    private TextMeshProUGUI factText;

    [SerializeField]
    private List<string> facts;

    private void Start()
    {
        factText = GetComponent<TextMeshProUGUI>();
        int factNumber = Random.Range(0, facts.Count);
        factText.text = facts[factNumber];
    }
}
