using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    [SerializeField]
    private ImageFade imageFade;

    private static LoadManager instance;
    public static LoadManager Instance => GetInstance();

    private bool isUsed = false;

    private static LoadManager GetInstance()
    {
        if (instance == null)
        {
            var gobj = new GameObject("Generated Load Manager");
            instance = gobj.AddComponent<LoadManager>();
        }
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
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
            isUsed = true;

            SceneManager.LoadScene(sceneName);
        });

    }

    void OnLevelWasLoaded(int level)
    {
        if (!isUsed)
            return;
        imageFade.SetTarget(0, (reached) => {

            Destroy(gameObject);

        });
    }
}
