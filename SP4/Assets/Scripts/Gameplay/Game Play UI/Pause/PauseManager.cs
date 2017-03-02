using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class PauseManager : MonoBehaviour {
	
	//for toggling pausescene
	private bool isPausedScene;
	private bool isQuitScene;
	//for debugging pause scene
	public GameObject pauseScene;
	public GameObject quitScene;
    public GameObject Scene;
    public Button Miner, Warrior, Archer;

	// Use this for initialization
	void Start () {
		isPausedScene = false;
		isQuitScene = false;

        Miner.onClick.AddListener(delegate { Scene.GetComponent<WaveManager>().SpawnMobs(1); });
        Warrior.onClick.AddListener(delegate { Scene.GetComponent<WaveManager>().SpawnMobs(2); });
        Archer.onClick.AddListener(delegate { Scene.GetComponent<WaveManager>().SpawnMobs(3); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TogglePause()
	{
		if (isPausedScene)
		{
			//When pause button is pressed, go back to game play
			Time.timeScale = 1;
			isPausedScene = false;
			pauseScene.SetActive (false);
		}
		else 
		{
			//When pause button is pressed, go to pause menu
			Time.timeScale = 0;
			isPausedScene = true;
			pauseScene.SetActive (true);
		}
	}

	public void ToggleQuit()
	{
		if (isQuitScene)
		{
			//When Quit button is pressed, go back to pause menu
			isQuitScene = false;
			quitScene.SetActive (false);
		} 
		else 
		{
			//When QUit button is pressed, go to quit menu
			isQuitScene = true;
			quitScene.SetActive (true);
		}
	}

	public void QuitGame()
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		SceneManager.LoadScene ("GameOver");
	}
}
