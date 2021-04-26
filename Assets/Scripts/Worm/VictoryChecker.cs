using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField]
    private float coreY;

    [SerializeField]
    private UnityEvent OnVictory;

    private void Update()
    {
        if (transform.position.y <= coreY)
        {
            OnVictory?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x - 10000, coreY, 0), new Vector3(transform.position.x + 10000, coreY, 0));
    }

}
