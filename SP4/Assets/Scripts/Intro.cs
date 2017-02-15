using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour 
{
    bool HavePlayerName;
    float SplashTimer;
    string playerName;
	// Use this for initialization
	void Start () 
    {
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

            Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height), width, height);
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
}
