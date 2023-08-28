using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalInstrument : MonoBehaviour
{
    private Vector3 initialScale;

    protected void Start()
    {
        initialScale = transform.localScale;
        UpdateScale();
    }

    private void UpdateScale()
    {
        transform.localScale = initialScale * (Screen.height / 1920f);
    }
    
}
