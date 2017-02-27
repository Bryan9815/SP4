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
        Hero1.sprite = GlobalVariable.GetPlayerHero(1).GetComponent<Hero>().GetSprite();
        Hero2.sprite = GlobalVariable.GetPlayerHero(2).GetComponent<Hero>().GetSprite();
        Hero3.sprite = GlobalVariable.GetPlayerHero(3).GetComponent<Hero>().GetSprite();

        Stats1.text = GlobalVariable.PrintPlayerHeroStats(1);
        Stats2.text = GlobalVariable.PrintPlayerHeroStats(2);
        Stats3.text = GlobalVariable.PrintPlayerHeroStats(3);

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
        {
            PlayerPrefs.SetInt("Highest Wave Reached", WaveManager.GetWaveNumber());
            PlayerPrefs.SetInt("Highest Hero_1", GlobalVariable.GetPlayerHeroID(1));
            PlayerPrefs.SetInt("Highest Hero_2", GlobalVariable.GetPlayerHeroID(2));
            PlayerPrefs.SetInt("Highest Hero_3", GlobalVariable.GetPlayerHeroID(3));
        }
        if (WaveManager.GetGoldEarned() > PlayerPrefs.GetInt("Most Gold Earned", 0))
            PlayerPrefs.SetInt("Most Gold Earned", WaveManager.GetGoldEarned());
        if (WaveManager.GetKillCount() > PlayerPrefs.GetInt("Most Kills", 0))
            PlayerPrefs.SetInt("Most Kills", WaveManager.GetKillCount());

        SceneManager.LoadScene("MainMenu");
    }
}
