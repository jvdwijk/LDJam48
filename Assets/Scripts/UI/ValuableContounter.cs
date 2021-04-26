using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuableContounter : MonoBehaviour
{

    [SerializeField]
    private ValuableScoreUI scoreUIPrefab;

    [SerializeField]
    private Transform valuableList;

    [SerializeField]
    private Portefeuille portefeuille;

    private Dictionary<string, ValuableScoreUI> scoreUIs = new Dictionary<string, ValuableScoreUI>();
    
    void Start()
    {
        var keeper = GameObject.Find("ValuableKeeper").GetComponent<ValuableKeeper>();
        var valuables = keeper.GetValuables;

        foreach (var valuable in valuables)
        {
            if (!scoreUIs.ContainsKey(valuable.name))
            {
                ValuableScoreUI onion = Instantiate(scoreUIPrefab);
                onion.Init(valuable);
                onion.transform.SetParent(valuableList);
                onion.transform.localScale = Vector3.one;
                scoreUIs.Add(valuable.name, onion);
            }

            portefeuille.AddCurrency(valuable.price);
            ValuableScoreUI scoreUI = scoreUIs[valuable.name];
            scoreUI.AddOne();
        }

        Destroy(keeper.gameObject);
    }
}
