﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
	}

    public void GoToTown()
    {
        SceneManager.LoadScene("Town");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }
}