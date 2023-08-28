using System;
using System.Collections.Generic;
using Jackal;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Songs ", menuName = "Data/Scriptable Object/Song Infor SO")]
public class SongSO : ScriptableObject
{
    public List<SongInfor> songInfors;

    public SongInfor GetSongWithID(SongID id)
    {
        int n = songInfors.Count;
        for (int i = 0; i < n; i++)
        {
            if(id == songInfors[i].songID) return songInfors[i];
        }

        return null;
    }
}

[Serializable]
public class SongInfor
{
    public SongID songID;
    public string name;
    public int price = 200;
    [FormerlySerializedAs("song")] public AudioClip[] songs;
    public GameObject musicalObject;
}