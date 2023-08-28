using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour
{
    private AudioManager _audioManager;

    protected virtual void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    public virtual void Play(int id)
    {
        _audioManager.PlaySong(id);
    }
}
