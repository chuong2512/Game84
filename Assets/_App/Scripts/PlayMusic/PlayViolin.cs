using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayViolin : PlayMusic
{
    public Transform horsehairBow;
    private bool isHold;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private Vector2 prePos;
    private Ray ray;
    private bool hasPassed;
    private bool isSwiping;
    private bool isPlayMusic;
    private float minX = -200f;// * (Screen.height / 1920f);
    private float maxX = 200f;// * (Screen.height / 1920f);

    /*private void OnEnable()
    {
        minX = 350f * (Screen.height / 1920f);
        maxX = 600f * (Screen.height / 1920f);
    }*/

    public void OnPointerDown()
    {
        isHold = true;
    }

    public void OnPointerUp()
    {
        isHold = false;
    }
    
    private void Update()
    {
        Vector2 currentTouchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) 
        {
            touchStartPos = currentTouchPos;
            prePos = touchStartPos;
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            touchEndPos = currentTouchPos;
            isSwiping = false;
        }

        if (isSwiping)
        {
            float x = currentTouchPos.x - prePos.x;
            if (Math.Abs(x) < 0.01f) return;
            var position = horsehairBow.localPosition;
            float crtX = position.x + x;
            crtX = Mathf.Clamp(crtX, minX, maxX);
  
            position = new Vector3(crtX, position.y, position.z);
            horsehairBow.localPosition = position;
            GuitarPlay();
        }

        prePos = currentTouchPos;
    }
    
    private void GuitarPlay()
    {
        int i = isHold ? 0 : 1;
        Play(i);
    }
}
