using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuebleKepperDestoyer : MonoBehaviour
{
    void Start()
    {
        GameObject keeper = GameObject.Find("ValuableKeeper");
        if(keeper != null)
            Destroy(keeper);
    }

}
