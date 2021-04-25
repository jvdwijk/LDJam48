using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMaintainer : MonoBehaviour
{
    private void Update()
    {
        if (PlayerPrefs.GetInt("controllerType") == (int) ControllerTypes.Mouse) {
            float horizontalAxis = Input.GetAxis("Horizontal");
            if (horizontalAxis != 0)
                PlayerPrefs.SetInt("controllerType", (int) ControllerTypes.Controller);
        }
        else
        {
            float horizontalAxis = Input.GetAxis("Mouse X");
            float verticalAxis = Input.GetAxis("Mouse Y");

            if (horizontalAxis != 0 || verticalAxis != 0)
                PlayerPrefs.SetInt("controllerType", (int) ControllerTypes.Mouse);
        }


    }
}
