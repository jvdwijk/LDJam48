using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicController : MonoBehaviour
{

    [SerializeField]
    private float safeValue = 0.95f;

    [SerializeField]
    private float waitTime = 3;

    [SerializeField]
    private List<AudioClipInfo> clipInfos;

    [SerializeField]
    private AudioSource mainAudioSource, oldAudioSource;
    private UpgradeManager manager;

    private void Start()
    {
        manager = UpgradeManager.Instance;
        float fractionUnlocked = manager.GetPercentageUnlocked();

        for (int i = 0; i < clipInfos.Count; i++)
        {
            if (fractionUnlocked < clipInfos[i].fraction)
                continue;

            IEnumerator switchSongsCoroutine = SwitchSongs(i);
            StartCoroutine(switchSongsCoroutine);

            return;
        }
    }

    // glitter
    private IEnumerator SwitchSongs(int songNumber)
    {
        int oldNumber = PlayerPrefs.GetInt("ClipInfoNumber");
        
        if (oldNumber != 0 && oldNumber != songNumber)
        {
            mainAudioSource.volume = 0;
            oldAudioSource.volume = 1;

            oldAudioSource.clip = clipInfos[oldNumber].clip;
            mainAudioSource.clip = clipInfos[songNumber].clip;

            oldAudioSource.Play();
            mainAudioSource.Play();


            yield return new WaitForSeconds(waitTime);

            while (mainAudioSource.volume <= safeValue)
            {
                mainAudioSource.volume += 0.01f;

                if (mainAudioSource.volume >= 0.5f)
                    oldAudioSource.volume -= 0.02f;

                yield return null;
            }
            mainAudioSource.volume = 1;
            oldAudioSource.volume = 0;
        }
        else
        {
            mainAudioSource.volume = 1;

            mainAudioSource.clip = clipInfos[songNumber].clip;
            mainAudioSource.Play();
        }
        
        PlayerPrefs.SetInt("ClipInfoNumber", songNumber);

        //glitter
    }
}
