﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;
    private Image fadePanel;
    private Color currentColor = Color.black;

    // Use this for initialization
    void Start () {
		gameObject.SetActive (true);
        fadePanel = GetComponent<Image>();


    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false); 
		// disable the panel when time is out
		// after alpha has gone from 255 to zero
        }
    }
}
