using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    private float hungerRate = 1;

    [SerializeField]
    private float safetyTime = 5;

    private float hungerMult = 1;
    private Health health;

    private bool safetyOn = true;

    public float HungerRate
    {
        get { return hungerRate; }
        set { hungerRate = value; }
    }

    private void Start()
    {
        health = GetComponent<Health>();
        Invoke("SafetyTime", safetyTime);
    }

    void Update()
    {
        if (safetyOn)
            return;
        float damage = hungerRate * hungerMult;

        //todo: multiply damage on higher dept 
        health.Damage(damage * Time.deltaTime); //damage over time
        //todo: hunger reduction
    }

    private void SafetyTime()
    {
        safetyOn = false;
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
