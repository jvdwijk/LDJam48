using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuableKeeper : MonoBehaviour
{
    [SerializeField]
    private List<ValuableStats> valuables = new List<ValuableStats>();

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void AddValuable(ValuableStats valuable)
    {
        valuables.Add(valuable);
    }

    public List<ValuableStats> GetValuables
    {
        get { return valuables; }
    }

}
