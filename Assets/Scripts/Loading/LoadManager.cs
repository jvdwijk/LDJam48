using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    [SerializeField]
    private ImageFade imageFade;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        imageFade.SetTarget(1, (reached) =>
        {
            if (!reached)
            {
                return;
            }

            SceneManager.LoadScene(sceneName);
        });

    }

    void OnLevelWasLoaded(int level)
    {
        imageFade.SetTarget(0);
    }


}
