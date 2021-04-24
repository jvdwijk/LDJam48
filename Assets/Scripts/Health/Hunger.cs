using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    private float hungerRate = 1;
    private Health health;

    void Update()
    {
        health.Damage(hungerRate * Time.deltaTime); //damage over time
        //todo: multiply damage on higher dept
        //todo: hunger reduction
    }
}
