using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer Audio;

    public void SetVolume(float volume)
    {
        Audio.SetFloat("Volume", volume);
    }

}
