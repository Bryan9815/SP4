using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HighScore : MonoBehaviour 
{
    public Leaderboard lb;
    bool displayLeaderboard = false;
    List<Leaderboard.Score> scoreList;

    public Button ReturnToMainMenu, TriggerLeaderboard;

    public Text WaveRecord, GoldRecord, Stats1, Stats2, Stats3;
    public Image Hero1, Hero2, Hero3;
    void Start()
    {
        StartCoroutine(RefreshRecords());

        ReturnToMainMenu.onClick.AddListener(delegate { SceneManager.LoadScene("MainMenu"); });
        TriggerLeaderboard.onClick.AddListener(delegate { displayLeaderboard = true; });
        // Call stats and hero records

        WaveRecord.text = "Wave Reached: " + PlayerPrefs.GetInt("Highest Wave Reached", 0).ToString();
        GoldRecord.text = "Gold Earned: " + PlayerPrefs.GetInt("Most Gold Earned", 0).ToString();
    }

    IEnumerator RefreshRecords()
    {
        while (true)
        {
            lb.AddScore(PlayerPrefs.GetString("userID"), PlayerPrefs.GetInt("Highest Wave Reached", 0));
            scoreList = lb.ToListHighToLow();
            Debug.Log("scoreList Count: " + scoreList.Count.ToString());
            yield return new WaitForSeconds(5);
        }
    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (displayLeaderboard)
        {
            float width = Screen.width * 0.8f;  // Make this wider to add more columns
            float height = Screen.height * 0.8f;

            GUILayoutOption[] layout = new GUILayoutOption[] { GUILayout.Width(width / 2.8f) };

            Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height / 2), width, height);
            GUILayout.BeginArea(r, new GUIStyle("box"));

            GUILayout.BeginVertical();
            GUILayout.Label("High Scores:");
            //Debug.Log("scoreList Count: " + scoreList.Count.ToString());

            if (scoreList == null)
            {
                GUILayout.Label("(loading...)");
            }
            else
            {
                int maxToDisplay = 20;
                int count = 0;
                foreach (Leaderboard.Score currentScore in scoreList)
                {
                    count++;
                    //Debug.LogError("Printing List");
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(currentScore.playerName, layout);
                    GUILayout.Label("Wave Reached: " + currentScore.score.ToString(), layout);
                    GUILayout.Label(currentScore.dateString.ToString(), layout);
                    GUILayout.EndHorizontal();

                    if (count >= maxToDisplay || count >= scoreList.Count)
                        break;
                }
            }
            if (GUILayout.Button("Close"))
            {
                displayLeaderboard = false;
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
