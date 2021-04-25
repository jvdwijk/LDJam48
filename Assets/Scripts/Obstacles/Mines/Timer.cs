using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent done;

    private float time;
    private bool running;

    public void StartTimer(float DurationInSecs)
    {
        if (!running)
        {
            time = DurationInSecs;
            running = true;
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(running && time < 0)
        {
            running = false;
            done.Invoke();
        }
    }
}
