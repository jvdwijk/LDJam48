using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    [SerializeField]
    private ImageFade imageFade;

    private bool isUsed = false;

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
