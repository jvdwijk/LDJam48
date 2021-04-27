using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudio : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup mixer;
    [SerializeField]
    private string exposed;

    public void ChangeVolume(float volume)
    {
        print(mixer.audioMixer.SetFloat(exposed, Mathf.Log10(volume) * 20));

    }
}
