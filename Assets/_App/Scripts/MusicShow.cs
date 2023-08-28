using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicShow : MonoBehaviour
{
    public Button button;
    
    private void Start()
    {
        GameDataManager gameDataManager = GameDataManager.Instance;
        GameObject musical = gameDataManager.songSo.GetSongWithID(gameDataManager.currentID).musicalObject;
        musical = Instantiate(musical, transform);
        button.transform.SetSiblingIndex(transform.childCount - 1);
        button.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene("Main UI");
    }
}
