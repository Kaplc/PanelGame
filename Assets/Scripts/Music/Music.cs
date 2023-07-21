using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;
    public static Music Instance => instance;

    private AudioSource audioSource;
    
    private void Awake()
    {
        instance = this;
        audioSource = this.GetComponent<AudioSource>();
        ChangeMusicOpen(GameDataMgr.Instance.musicData.musicOpen);
        ChangeMusicVolume(GameDataMgr.Instance.musicData.musicVolume);
    }

    public void ChangeMusicOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }

    public void ChangeMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
