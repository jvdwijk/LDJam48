using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnDie;
    public UnityEvent OnChange;

    private float value = 100;
    private float max = 100;


    void Start()
    {
        OnDie = new UnityEvent();
    }

    public void Heal(float input)
    {
        value = Mathf.Min(value + input, max);
        OnChange.Invoke();
    }

    public void Damage(float input) //todo: bool ignore damage reduction
    {
        value -= input;
        //todo: damage reduction
        OnChange.Invoke();
    }

    void Update()
    {
        if (true)
        {
            OnDie.Invoke();
        }
    }
}
