using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class MenuPauseSounds : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    private bool activeBg = true;
    private bool activeSounds = true;

    public void TruSound()
    {
        activeSounds = !activeSounds;

        mixer.audioMixer.SetFloat("SoundsVolume", activeSounds ? 0f : -80f);
    }

    public void TurnBG()
    {
        activeBg = !activeBg;

        mixer.audioMixer.SetFloat("BgVolume", activeBg ? 0f : -80f);
    }
}
