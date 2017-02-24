using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour 
{
    public Image Hero1, Hero2, Hero3;
    public Text Stats1, Stats2, Stats3, Wave, Gold, Kills;
    public Button ReturnToMainMenu;
    // Use this for initialization
	void Start () 
    {
        // Use player team for hero images
        //Stats1.text = "Kills: " + Hero1.kills.ToString();

        Wave.text = "Wave Reached: " + WaveManager.GetWaveNumber();
        Gold.text = "Gold Earned: " + WaveManager.GetGoldEarned();
        Kills.text = "Kill Count: " + WaveManager.GetKillCount();

        ReturnToMainMenu.onClick.AddListener(delegate { BackToMainMenu(); });
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void BackToMainMenu()
    {
        if (WaveManager.GetWaveNumber() > PlayerPrefs.GetInt("Highest Wave Reached", 0))
            PlayerPrefs.SetInt("Highest Wave Reached", WaveManager.GetWaveNumber());
        if (WaveManager.GetGoldEarned() > PlayerPrefs.GetInt("Most Gold Earned", 0))
            PlayerPrefs.SetInt("Most Gold Earned", WaveManager.GetGoldEarned());
        if (WaveManager.GetKillCount() > PlayerPrefs.GetInt("Most Kills", 0))
            PlayerPrefs.SetInt("Most Kills", WaveManager.GetKillCount());

        SceneManager.LoadScene("MainMenu");
    }
}
