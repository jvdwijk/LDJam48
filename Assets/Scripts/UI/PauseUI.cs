using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseUI : UIControllerManager
{
    [SerializeField]
    private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField]
    private KeyCode controllerPauseKey = KeyCode.Joystick1Button16;
    [SerializeField]
    private Canvas pauseCanvas;

    [SerializeField]
    private string mainMenuSceneName = "Main Menu";

    [SerializeField]
    private string shopSceneName = "ScoreScreen";

    private float currentTimescale;


    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey) && !Input.GetKeyDown(controllerPauseKey))
            return;
        if (pauseCanvas.gameObject.activeInHierarchy) ClosePauseMenu();
        else OpenPauseMenu();
    }

    public void OpenPauseMenu()
    {
        pauseCanvas.gameObject.SetActive(true);
        currentTimescale = Time.timeScale;
        Time.timeScale = 0f;
        SetSelectedUIObject(firstSelected);

    }

    public void ClosePauseMenu()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = currentTimescale;
        SetSelectedUIObject(null);
    }


    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        LoadManager.Instance.LoadScene(mainMenuSceneName);
    }

    public void ToShop()
    {
        Time.timeScale = 1f;
        LoadManager.Instance.LoadScene(shopSceneName);
    }
}