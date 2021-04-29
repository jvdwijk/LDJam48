using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomFactPicker : MonoBehaviour
{
    private TextMeshProUGUI factText;

    [SerializeField]
    private List<string> facts;

    [SerializeField]
    private float upPosition, speedySpeed;
    private float contertje = 0, startY;


    private void Start()
    {
        startY = transform.localPosition.y;
        factText = GetComponent<TextMeshProUGUI>();
        int factNumber = Random.Range(0, facts.Count);
        factText.text = facts[factNumber];
        StartCoroutine(lerpPosition());
    }

    private IEnumerator lerpPosition()
    {
        while (true)
        {
        contertje += Time.deltaTime * speedySpeed;
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Sin(contertje) * upPosition + startY, 0);
        yield return null;
        }
    }
}
