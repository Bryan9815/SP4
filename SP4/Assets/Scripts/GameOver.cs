using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour 
{
    public Image Hero1, Hero2, Hero3;
    public Text Stats1, Stats2, Stats3, Wave, Gold;
    public Button ReturnToMainMenu;
    // Use this for initialization
	void Start () 
    {
        // Use player team for hero images
        //Stats1.text = "Kills: " + Hero1.kills.ToString();

        //Wave.text = "Wave Reached: " + waveNo;
        //Gold.text = "Gold Earned: " + goldEarned;

        ReturnToMainMenu.onClick.AddListener(delegate { BackToMainMenu(); });
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void BackToMainMenu()
    {
        //if (waveNo > PlayerPrefs.GetInt("waveRecord", 0))
        //    PlayerPrefs.SetInt("waveRecord", waveNo);
        // Same for hero kills, etc
        SceneManager.LoadScene("MainMenu");
    }
}
