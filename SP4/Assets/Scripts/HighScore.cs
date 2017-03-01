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

    public Text WaveRecord, GoldRecord, KillRecord, Stats1, Stats2, Stats3;
    public Image Hero1, Hero2, Hero3;
    public GUIStyle AngryBirdFont;
    void Start()
    {
        ReturnToMainMenu.onClick.AddListener(delegate { SceneManager.LoadScene("MainMenu"); });
        TriggerLeaderboard.onClick.AddListener(delegate { displayLeaderboard = true; });

        WaveRecord.text = "Wave Reached: " + PlayerPrefs.GetInt("Highest Wave Reached", 0).ToString();
        GoldRecord.text = "Gold Earned: " + PlayerPrefs.GetInt("Most Gold Earned", 0).ToString();
        KillRecord.text = "Kill Count: " + PlayerPrefs.GetInt("Most Kills", 0).ToString();

        // Call stats and hero records
        Hero1.sprite = GlobalVariable.GetHero(PlayerPrefs.GetInt("Highest Hero_1", 1)).GetComponent<Hero>().GetSprite();
        Hero2.sprite = GlobalVariable.GetHero(PlayerPrefs.GetInt("Highest Hero_2", 2)).GetComponent<Hero>().GetSprite();
        Hero3.sprite = GlobalVariable.GetHero(PlayerPrefs.GetInt("Highest Hero_3", 3)).GetComponent<Hero>().GetSprite();

        Stats1.text = GlobalVariable.PrintHeroStats(PlayerPrefs.GetInt("Highest Hero_1", 1));
        Stats2.text = GlobalVariable.PrintHeroStats(PlayerPrefs.GetInt("Highest Hero_2", 2));
        Stats3.text = GlobalVariable.PrintHeroStats(PlayerPrefs.GetInt("Highest Hero_3", 3));
        
        lb.AddScore(PlayerPrefs.GetString("userID"), PlayerPrefs.GetInt("Highest Wave Reached", 0));
        
        StartCoroutine(RefreshRecords());
    }

    IEnumerator RefreshRecords()
    {
        while (true)
        {
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
            GUIStyle font = new GUIStyle();
            font = AngryBirdFont;
            GUILayout.Label("High Scores:", font);
            //Debug.Log("scoreList Count: " + scoreList.Count.ToString());

            if (scoreList == null || scoreList.Count == 0)
            {
                GUILayout.Label("(loading...)", font);
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
                    GUILayout.Label(currentScore.playerName, font, layout);
                    GUILayout.Label("Wave Reached: " + currentScore.score.ToString(), font, layout);
                    GUILayout.Label(currentScore.dateString.ToString(), font, layout);
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
