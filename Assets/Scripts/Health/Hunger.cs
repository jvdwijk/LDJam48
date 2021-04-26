using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public  float hungerRate = 1;
    private float hungerMult = 1;
    private Health health;

    public float HungerRate
    {
        get { return hungerRate; }
        set { hungerRate = value; }
    }

    private void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        health.Damage(hungerRate * hungerMult * Time.deltaTime); //damage over time
        //todo: multiply damage on higher dept
        //todo: hunger reduction
    }

    public void multHunger(float input)
    {
        hungerMult *= input;
    }

    public void resetHungerMult(float input)
    {
        hungerMult = 1;
    }
}
