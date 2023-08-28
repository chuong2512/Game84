using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrumpet : PlayMusic
{
    private bool isBlow;
    public float minTimeToTap = 1f;
    private float countTime = 0;
    
    public void OnPointerDown()
    {
        isBlow = true;
    }

    public void OnPointerUp()
    {
        isBlow = false;
    }

    public void resetTime()
    {
        countTime = 0;
    }
    
    private void FixedUpdate()
    {
        if (isBlow)
        {
            if (countTime > minTimeToTap) Play(0);
            else
            {
                countTime += Time.fixedDeltaTime;
                Play(1);
            }
        }
    }
}
