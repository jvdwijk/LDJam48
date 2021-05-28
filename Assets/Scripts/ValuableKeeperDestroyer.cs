using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuableKeeperDestroyer : MonoBehaviour
{
    void Start()
    {
        var keeperGameobj = GameObject.Find("ValuableKeeper");

        if(keeperGameobj == null)
        {
            return;
        }

        Destroy(keeperGameobj);
    }
}
