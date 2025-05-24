using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayAudio: MonoBehaviour
{
    [SerializeField] private AudioClip soundJump;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySoundJump()
    {
        audio.clip = soundJump;
        audio.Play();
    } 
   
}

