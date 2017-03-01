using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour 
{
	public GameObject[] tutorialSequence;

	//for counting which step or which tutorial number they are on
	private int counter;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
		counter = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < tutorialSequence.Length; i++) {
			if (i != counter)
				tutorialSequence [i].SetActive (false);
			else
				tutorialSequence [i].SetActive (true);
		}

		//end of tutorial
		if (counter == tutorialSequence.Length) 
		{
			Time.timeScale = 1;
			SceneManager.LoadScene ("Town");
		}
	}

	public void Next()
	{
		counter++;		
	}
}
