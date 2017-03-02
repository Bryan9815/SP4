﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Town : MonoBehaviour {
    bool SeenTutorial;
    bool started = false;
    public Canvas displayMode;
    bool toShopB = false, toCharSelectB = false, toEndlessB = false;
    float timer = 1.0f;
    private AudioSource ThatAudioSource;
	// Use this for initialization
	void Start ()
    {
        SeenTutorial = BoolPrefs.GetBool("Seen Tutorial", false);
        ThatAudioSource = GameObject.Find("TownMusic").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!SeenTutorial)
        {
            SceneManager.LoadScene("TownTutorial");
        }

        ThatAudioSource.volume = PlayerPrefs.GetFloat("Music")/100;
        if (toShopB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene("TownShop");
        } if (toCharSelectB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene("SelectHeroes");
        } if (toEndlessB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene("GamePlay");
        }
	   
	}
    public void OpenMode()
    {
        if (!started)
        {
            started = true;
            displayMode.enabled = true;
        }
    }
    public void CloseMode()
    {
        if (started)
        {
            started = false;
            displayMode.enabled = false;
        }
    }

    public void EndlessMode()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        toEndlessB = true;
    }

    public void goToMain()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        SceneManager.LoadScene("MainMenu");
    }

    public void goToShop()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack()); 
        toShopB = true;
    }

    public void goToCharSelect()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        toCharSelectB = true;
    }
}
