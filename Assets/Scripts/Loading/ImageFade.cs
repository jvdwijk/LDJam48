using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{

    private const float APPROX_ZERO = 0.01f;

    [SerializeField]
    private Image image;

    [SerializeField]
    private float fadeSpeed;

    private float targetAlpha = 0;

    private Action<bool> currentCallback;


    public void SetTarget(int target, Action<bool> targetReachedCallback = null)
    {
        targetAlpha = target;

        if (currentCallback != null)
        {
            currentCallback.Invoke(false);
        }

        currentCallback = targetReachedCallback;
    }

    private void Update()
    {
        float currentAlpha = image.color.a;
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
        
        if(Math.Abs(newAlpha - targetAlpha) <= APPROX_ZERO)
        {
            newAlpha = targetAlpha;
        }

        SetImageAlpha(newAlpha);

        image.enabled = newAlpha > 0;

        if (Math.Abs(newAlpha - targetAlpha) <= APPROX_ZERO && currentCallback != null)
        {
            currentCallback.Invoke(true);
            currentCallback = null;
        }
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

}
