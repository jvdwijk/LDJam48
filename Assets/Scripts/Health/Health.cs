using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityFloatEvent : UnityEvent<float>{}

public class Health : MonoBehaviour
{
    [SerializeField]
    private string sceneToDieFor = "ScoreScreen";

    [SerializeField]
    private UnityEvent OnDie;
   
    [SerializeField]
    private UnityFloatEvent OnChange;


    [SerializeField]
    private float value, max = 100;

    public float Value
    {
        get { return value; }
    }

    public float Max
    {
        get { return max; }
        set { max = value; }
    }


    private void Start()
    {
        OnChange.Invoke(value);
    }

    public void Heal(float input)
    {
        value = Mathf.Min(value + input, max);
        OnChange.Invoke(value);
    }

    public void Damage(float input) //todo: bool ignore damage reduction
    {
        value -= input;
        //todo: damage reduction
        OnChange.Invoke(value);

        if (value < 0)
        {
            JimGoDie();
        }
    }

    private void JimGoDie()
    {
        OnDie?.Invoke();
        LoadManager.Instance.LoadScene(sceneToDieFor);
    }
}
