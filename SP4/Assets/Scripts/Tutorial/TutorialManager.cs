using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour 
{
	public GameObject[] tutorialSequence;
	public GameObject[] gameplayTutorialSequence;
	private Scene scene;
	public GameObject loadingScreen;
	public GameObject enemy;
	public GameObject attackCollider;
	bool runGameplayTutorial;
	public static float distance;

	//for counting which step or which tutorial number they are on
	public static int counter;

	// Use this for initialization
	void Start () 
	{
		runGameplayTutorial = false;
		distance = 1.0f;
		scene = SceneManager.GetActiveScene ();
		loadingScreen.SetActive (false);
		Time.timeScale = 0;
		counter = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (runGameplayTutorial) {
			for (int i = 0; i < gameplayTutorialSequence.Length; i++) {
				if (i != counter)
					gameplayTutorialSequence [i].SetActive (false);
				else
					gameplayTutorialSequence [i].SetActive (true);
			}
		} 
		else 
		{
			for (int i = 0; i < tutorialSequence.Length; i++) {
				if (i != counter)
					tutorialSequence [i].SetActive (false);
				else
					tutorialSequence [i].SetActive (true);
			}
		}
		Debug.Log ("preCounter = " + counter);

		//end of tutorial
		if (runGameplayTutorial) 
		{
			if (counter == gameplayTutorialSequence.Length) 
			{
				SceneManager.LoadScene("Town");
				loadingScreen.SetActive(false);
			}
		} 
		else
		{
			if (counter == tutorialSequence.Length)
			{
				loadingScreen.SetActive (true);
				scene = SceneManager.GetActiveScene ();
				if (scene.name == "TownTutorial")
					SceneManager.LoadScene ("Tutorial");
				else if (scene.name == "Tutorial")
				{
					distance = Mathf.Sqrt ((float)(enemy.transform.position.x - attackCollider.transform.position.x) * (enemy.transform.position.x - attackCollider.transform.position.x));
					Time.timeScale = 1;

					if (distance <= 0.5f)
					{
						Time.timeScale = 0;
						counter = 0;
						runGameplayTutorial = true;
					}
				}

			}
		}
	}

	public void Next()
	{
		counter++;
		if (counter > tutorialSequence.Length)
			counter = tutorialSequence.Length;
	}

	public void Back()
	{
		counter--;
		if (counter <= 0)
			counter = 0;
	}
}
