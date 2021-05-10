using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenResizePoller : MonoBehaviour
{
    public UnityEvent onScreenResize;

    [SerializeField]
    private Camera cam;

    private int screenHeight, screenWidth;

    private void Reset()
    {
        cam = Camera.main;
    }

    private void Awake()
    {
        ResetScreenSize();
    }

    void Update()
    {
        if (CheckScreenSizeChaned())
        {
            ResetScreenSize();
            onScreenResize?.Invoke();
            print(screenHeight);
        }
    }

    private bool CheckScreenSizeChaned()
    {
        return screenHeight != cam.scaledPixelHeight || screenWidth != cam.scaledPixelWidth;
    }

    private void ResetScreenSize()
    {
        screenHeight = cam.scaledPixelHeight;
        screenWidth = cam.scaledPixelWidth;
    }
}
