using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour 
{
    bool HavePlayerName;
    float SplashTimer;
    string playerName = "";

    int windowMode, Resolution;
	// Use this for initialization
	void Start () 
    {
        windowMode = PlayerPrefs.GetInt("winMode", 0);
        Resolution = PlayerPrefs.GetInt("Resolution", 0);

        UpdateWindow();

        if (PlayerPrefs.GetString("userID") == "")
            HavePlayerName = false;
        else
            HavePlayerName = true;

        SplashTimer = 3.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (HavePlayerName)
        {
            SplashTimer -= Time.deltaTime;
            if (SplashTimer <= 0.0f)
                SceneManager.LoadScene("MainMenu");
        }
	}

    void OnGUI()
    {
        if (!HavePlayerName)
        {
            float width = Screen.width * 0.3f;  // Make this wider to add more columns
            float height = Screen.height * 0.3f;
            GUILayoutOption[] layout = new GUILayoutOption[] { GUILayout.Width(width / 2.8f) };

            Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2), width, height * 0.2f);
            GUILayout.BeginArea(r, new GUIStyle("box"));

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Enter Your Name: ");
            this.playerName = GUILayout.TextField(this.playerName, layout);

            if (GUILayout.Button("Ok"))
            {
                PlayerPrefs.SetString("userID", playerName);

                HavePlayerName = true;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }

    void UpdateWindow()
    {
        if (Resolution == 0)
        {
            GlobalVariable.SetScreenWidth(800);
            GlobalVariable.SetScreenHeight(600);
            if (windowMode == 0)
                Screen.SetResolution(800, 600, true);
            else
                Screen.SetResolution(800, 600, false);
        }
        else if (Resolution == 1)
        {
            GlobalVariable.SetScreenWidth(1024);
            GlobalVariable.SetScreenHeight(720);
            if (windowMode == 0)
                Screen.SetResolution(1024, 720, true);
            else
                Screen.SetResolution(1024, 720, false);
        }
        else if (Resolution == 2)
        {
            GlobalVariable.SetScreenWidth(1440);
            GlobalVariable.SetScreenHeight(810);
            if (windowMode == 0)
                Screen.SetResolution(1440, 810, true);
            else
                Screen.SetResolution(1440, 810, false);
        }
        else if (Resolution == 3)
        {
            GlobalVariable.SetScreenWidth(1600);
            GlobalVariable.SetScreenHeight(900);
            if (windowMode == 0)
                Screen.SetResolution(1600, 900, true);
            else
                Screen.SetResolution(1600, 900, false);
        }
        else if (Resolution == 4)
        {
            GlobalVariable.SetScreenWidth(1600);
            GlobalVariable.SetScreenHeight(1024);
            if (windowMode == 0)
                Screen.SetResolution(1600, 1024, true);
            else
                Screen.SetResolution(1600, 1024, false);
        }
        else if (Resolution == 5)
        {
            GlobalVariable.SetScreenWidth(1920);
            GlobalVariable.SetScreenHeight(1080);
            if (windowMode == 0)
                Screen.SetResolution(1920, 1080, true);
            else
                Screen.SetResolution(1920, 1080, false);
        }
    }
}
