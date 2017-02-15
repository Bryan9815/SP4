using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HighScore : MonoBehaviour 
{
    int totalScore = 0;
    string playerName = "";
    string code = "";

    public Leaderboard lb;

    void Start()
    {
        // get the reference here...
    }

    void Update()
    {

    }

    void OnGUI()
    {
        float width = Screen.width * 0.8f;  // Make this wider to add more columns
        float height = Screen.height * 0.8f;

        GUILayoutOption[] layout = new GUILayoutOption[] { GUILayout.Width(width / 2.8f) };

        Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height / 2), width, height);
        GUILayout.BeginArea(r, new GUIStyle("box"));

        GUILayout.BeginVertical();
        GUILayout.Label("High Scores:");
        List<Leaderboard.Score> scoreList = lb.ToListHighToLow();

        if (scoreList == null)
        {
            GUILayout.Label("(loading...)");
        }
        else
        {
            //Debug.LogError("Hi");
            lb.AddScore("Testing5", totalScore);
            int maxToDisplay = 20;
            int count = 0;
            foreach (Leaderboard.Score currentScore in scoreList)
            {
                count++;
                //Debug.LogError("Hi");
                GUILayout.BeginHorizontal();
                GUILayout.Label(currentScore.playerName, layout);
                GUILayout.Label("Wave Reached: " + currentScore.score.ToString(), layout);
                GUILayout.Label(currentScore.dateString.ToString(), layout);
                GUILayout.EndHorizontal();

                if (count >= maxToDisplay) break;
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
