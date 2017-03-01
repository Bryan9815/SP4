using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager: MonoBehaviour
{
	public GameObject flyingsprite;
	private Vector3 spawnPos;
	private float spawnTimer;
	private int spawnOnRight;
	private float topOfScreen;
	private float offSetY;
	private float tempX;
	private float tempY;
	private float tempScale;
	private float tempNumberofSprite;
	private GameObject tempMainMenu;
    private AudioSource mainMenuMusic;
	// Use this for initialization
	void Start () 
	{
		spawnTimer = 0.5f;
		spawnOnRight = 0;
		tempX = -GlobalVariable.GetScreenWidth () / 2;

		tempMainMenu = GameObject.Find ("MainMenu");
        mainMenuMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer -= Time.deltaTime;

        mainMenuMusic.volume = PlayerPrefs.GetFloat("Music")/100;
		if (spawnTimer < 0.0f) 
		{
			tempNumberofSprite = Random.Range (1, 5);
			for (int i = 0; i < tempNumberofSprite; i++) 
			{
				topOfScreen = tempMainMenu.GetComponent<RectTransform> ().rect.height / 2;
				offSetY = flyingsprite.GetComponent<Transform>().localScale.y / 2;

				tempY = Random.Range (offSetY, topOfScreen - offSetY);
				spawnOnRight = Random.Range (0, 2);

				switch (spawnOnRight)
				{
				case 0: 
					spawnPos = new Vector3 (tempX - Random.Range(5.0f,50.0f), tempY, -1.0f);
					break;
	
				case 1:
					spawnPos = new Vector3 (-tempX + Random.Range(5.0f,50.0f), tempY, -1.0f);
					break;
				}
				;

				GameObject spawn = Instantiate (flyingsprite, spawnPos, transform.rotation) as GameObject;
				spawn.transform.parent = gameObject.transform;
				spawn.transform.localPosition = spawnPos;
				tempScale = Random.Range (10.0f, 35.0f);
				spawn.transform.localScale = new Vector3 (tempScale, tempScale, 1.0f);
				spawnTimer = 3.0f;
			}
		}
	}
}
