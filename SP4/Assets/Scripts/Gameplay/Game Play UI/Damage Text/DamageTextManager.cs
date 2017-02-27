fusing UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageTextManager : MonoBehaviour 
{
    //GameObeject array for storing the sprite for 0 - 9 number
	public GameObject[] sprite_damage_text;
	static GameObject[] temp_sprite_damage_text = new GameObject[10];

	public GameObject[] playerTakeDamageText;
	static GameObject[] temp_playerTakeDamageText = new GameObject[10];

    // Use this for initialization
	void Start () 
	{
		for (int i = 0; i < sprite_damage_text.Length; i++)
			temp_sprite_damage_text [i] = sprite_damage_text[i];

		for (int i = 0; i < playerTakeDamageText.Length; i++)
			temp_playerTakeDamageText [i] = playerTakeDamageText[i];
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public static void GenerateSprite(Vector3 position, int damageToGenerate)
	{
		int damage = damageToGenerate;
		string damage_String = damage.ToString ();

		for (int i = 0; i < damage_String.Length; i++) 
		{
			char temp = damage_String [i];
			int tempCharSet = (int)temp;

			//48 = 0, 57 = 9
			//tempCharSet = tempCharSet - 48;

			Vector3 spawnPos = position;
			spawnPos.x = (0.46f * i) + position.x;
			GameObject numberSprite = temp_sprite_damage_text [tempCharSet - 48];
			GameObject spawn = Instantiate (numberSprite, spawnPos, numberSprite.transform.rotation) as GameObject;
			spawn.transform.localScale.Set (1.0f, 1.0f, 1.0f);
		}
	}

	public static void GeneratePlayerTakeDmg(Vector3 position, int damageToGenerate)
	{
		int damage = damageToGenerate;
		string damage_String = damage.ToString ();

		for (int i = 0; i < damage_String.Length; i++) 
		{
			char temp = damage_String [i];
			int tempCharSet = (int)temp;

			//48 = 0, 57 = 9
			//tempCharSet = tempCharSet - 48;

			Vector3 spawnPos = position;
			spawnPos.x = (0.46f * i) + position.x;
			GameObject numberSprite = temp_playerTakeDamageText [tempCharSet - 48];
			GameObject spawn = Instantiate (numberSprite, spawnPos, numberSprite.transform.rotation) as GameObject;
			spawn.transform.localScale.Set (1.0f, 1.0f, 1.0f);
		}
	}
}
