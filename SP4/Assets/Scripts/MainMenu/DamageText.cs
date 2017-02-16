using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageText : MonoBehaviour 
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

	//for transition effect of the Daamge
	float transitionX;

	//for where the damage sprite will come out from
	Vector3 spawnPos;

	//floating up values
	float scrollspeed;

	//To trigger display
	bool generateDamageText;

    // Use this for initialization
	void Start () 
	{
	    damage = 0;
	    damage_String = "";
		transitionX = 0.0f;
		spawnPos = new Vector3(0.0f,0.0f,0.0f);
		scrollspeed = 0.05f;
		generateDamageText = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		while (generateDamageText)
		{
			damage_String = damage.ToString ();

			for (int i = 0; i < damage_String.Length; i++) {
				temp = damage_String [i];
				tempCharSet = (int)temp;

				//48 = 0, 57 = 9
				//tempCharSet = tempCharSet - 48;
				spawnPos.x = 0.46f * i;
				GameObject numberSprite = sprite_damage_text [tempCharSet - 48];
				GameObject spawn = Instantiate (numberSprite, spawnPos, transform.rotation) as GameObject;
				spawn.transform.localScale.Set (1.0f, 1.0f, 1.0f);
				spawn.transform.Translate (0.0f,0.05f,0.0f);
			}
		}
	}

    public void GenerateSprite()
	{
		damage = Random.Range (0, 999);
		generateDamageText = true;
	}
}
