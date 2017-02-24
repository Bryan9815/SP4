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
	private float tempX;
	private float tempY;
	private float tempScale;
	private float tempNumberofSprite;

	// Use this for initialization
	void Start () 
	{
		spawnTimer = 1.0f;
		spawnOnRight = 0;
		tempX = -GlobalVariable.GetScreenWidth () / 2;

	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer -= Time.deltaTime;


		if (spawnTimer < 0.0f) 
		{
			tempNumberofSprite = Random.Range (1, 5);
			for (int i = 0; i < tempNumberofSprite; i++) 
			{
				tempY = Random.Range (120, 240);
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
