using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGuitar : PlayMusic
{
    private bool isHold;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private Ray ray;
    private bool hasPassed;
    private bool isSwiping;
    private bool isPlayMusic;
    

    public void OnPointerDown()
    {
        isHold = true;
        Debug.Log("hold");
    }

    public void OnPointerUp()
    {
        isHold = false;
        Debug.Log("up");
    }
    
    
    public void OnPointerExit()
    {
        Debug.Log("exit");
        GuitarPlay();
    }

    public void OnPointerEnd()
    {
        Play(2);
    }

    /*private void Update()
    {
        Vector2 currentTouchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) 
        {
            touchStartPos = currentTouchPos;
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            touchEndPos = currentTouchPos;
            isSwiping = false;
            if (hasPassed)
            {
                GuitarPlay();
            }
        }

        if (isSwiping)
        {
            Vector3 fingerPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            fingerPos.z = transform.position.z;
            
            bool check = objectCollider.OverlapPoint(objectCollider.transform.position);
            Debug.Log(check + " -- " + fingerPos + " -- " + objectCollider.transform.position);
            if (check)
            {
                hasPassed = true;
            }
            if (hasPassed && !check)
            {
                GuitarPlay();
            }
        }
    }*/

    private void GuitarPlay()
    {
        int i = isHold ? 0 : 1;
        Play(i);
    }
    

}
