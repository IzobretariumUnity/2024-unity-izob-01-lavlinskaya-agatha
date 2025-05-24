using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        SetRandomSound();
    }

    private void SetRandomSound()
    {
        audio.clip = RandomClip();
        audio.Play();
    }

    private AudioClip RandomClip()
    {
        return clips[Random.Range (0, clips.Length)];
    }
}
