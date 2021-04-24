using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnRunStart;

    private void Start()
    {
        OnRunStart.Invoke();
    }
}
