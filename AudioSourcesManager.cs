/***
  *Title:""��Ŀ
  *Description:
  *		����:
  *Author:D
  *Data:2018.03.18
  *
  *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcesManager : MonoBehaviour
{
    private static AudioSourcesManager _instance;
    public static AudioSourcesManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public AudioClip fire;
    public AudioClip getGold;
    public AudioClip lvPlus;
    public AudioSource bgAudioSources;

    private bool isMute = true;
    public bool IsMute
    {
        get
        {
            return isMute;
        }
    }
    public void SwitchIsMute()
    {
        isMute = !isMute;
        if (isMute)
        {
            bgAudioSources.Play();
        }
        else
        {
            bgAudioSources.Pause();
        }
    }
    
    public void PlayAudioSound(AudioClip clip)
    {
        if (isMute)
        {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        }
    }

}

