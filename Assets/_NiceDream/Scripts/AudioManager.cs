using System;
using Jackal;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-99)]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicSource;
    public AudioClip[] audioClips;
    public SongID songID;
    public float timePlay = 0.6f;
    public float timeCount;
    private bool isPlaying;
    private int crtId = -1;

    private int length;
    
    private void Start()
    {
        songID = GameDataManager.Instance.currentID;
        audioClips = GameDataManager.Instance.songSo.GetSongWithID(songID).songs;
        length = audioClips.Length;
        musicSource.loop = true;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            if (timeCount > 0) timeCount -= Time.fixedDeltaTime;
            else
            {
                musicSource.Stop();
                isPlaying = false;
            }
        }
    }
    
    public void PlaySong(int id)
    {
        //musicSource.clip = _songSo.GetSongWithID(id).song;
        if (id >= length) id = length - 1;
        if (crtId == id)
        {
            if (!isPlaying)
            {
                musicSource.Play();
                isPlaying = true;
            }
            timeCount = timePlay;
            return;
        }

        crtId = id;
        musicSource.clip = audioClips[id];
        musicSource.Play();
        isPlaying = true;
        timeCount = timePlay;
    }


}