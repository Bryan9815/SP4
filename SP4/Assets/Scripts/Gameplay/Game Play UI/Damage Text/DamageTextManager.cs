using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageTextManager : MonoBehaviour 
{
    //GameObeject array for storing the sprite for 0 - 9 number
	public GameObject[] sprite_damage_text;

    //for storing damage number
    int damage;

    //for display effects
    string damage_String;

    //for each number in the damage string
    char temp;

    //for each number in damage string as char set
    int tempCharSet;

	//for where the damage sprite will come out from
	Vector3 spawnPos;



    // Use this for initialization
	void Start () 
	{
	    damage = 0;
	    damage_String = "";
		spawnPos = new Vector3(0.0f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	//Debug testing purposes
	public void UpdateWaveNumber()//								(To Be Changed)
	{
		int tempWave = GlobalVariable.GetWaveNumber ();
		int tempStage = GlobalVariable.GetStageLevel ();

		GlobalVariable.SetWaveNumber (tempWave + 1);
		if (GlobalVariable.GetWaveNumber () > GlobalVariable.GetMaxWaveNumber ()) 
		{
			SceneManager.LoadScene ("Options_Window");
			GlobalVariable.SetWaveNumber (1);
			GlobalVariable.SetStageLevel (tempStage + 1);
		}
	}

	public void GenerateSprite()//								(To Be Changed)
	{
		damage = Random.Range (0, 999);
		damage_String = damage.ToString ();

		for (int i = 0; i < damage_String.Length; i++) 
		{
			temp = damage_String [i];
			tempCharSet = (int)temp;

			//48 = 0, 57 = 9
			//tempCharSet = tempCharSet - 48;

			spawnPos.x = 0.46f * i;
			GameObject numberSprite = sprite_damage_text [tempCharSet - 48];
			GameObject spawn = Instantiate (numberSprite, spawnPos, transform.rotation) as GameObject;
			spawn.transform.localScale.Set (1.0f, 1.0f, 1.0f);
		}
	}
}
