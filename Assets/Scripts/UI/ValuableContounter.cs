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

    [SerializeField]
    private GameObject pouch;

    private Dictionary<string, ValuableScoreUI> scoreUIs = new Dictionary<string, ValuableScoreUI>();
    
    void Start()
    {
        var keeperGameobj = GameObject.Find("ValuableKeeper");

        if (keeperGameobj == null)
        {
            pouch.SetActive(true);
            return;
        }

        var keeper = keeperGameobj.GetComponent<ValuableKeeper>();

        

        var valuables = keeper.GetValuables;
        if(valuables.Count > 0)
        {
            DisplayValuables(valuables);
        }
        else
        {
            pouch.SetActive(true);
        }
        

        Destroy(keeper.gameObject);
    }

    private void DisplayValuables(List<ValuableStats> valuables)
    {
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
    }


}
