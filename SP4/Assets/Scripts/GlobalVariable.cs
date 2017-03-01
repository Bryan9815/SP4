using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GlobalVariable : MonoBehaviour {

    private static float screenWidth;
    private static float screenHeight;
    private static string PlayerName;
    private static int PlayerGoldG;

	//Indicates how far the player is in
	private static int stageLevel;

	private static bool runTutorial;

    //Added using unity engine UI on top
    //is for just in case anyone need a global Text field 
    //or anything related in UI

    //===How to access global variable from other scripts===
    // type in your script GlobalScript.AnyVariableYouWant;
    // example : somefloatvariable = GlobalScript.GetScreenWidth();

    //===How to make a global variable===
    //1st. Set to private
    //2nd. Set to static variable  
    //3rd. Set the variable you want
    //4th. Set Variable Name

    //===How to make a global function===
    //1st. Set to public
    //2nd. Set to static funtcion
    //3rd. Set the function you want
    //4th. Set Function Name

	void Awake()
	{
		screenWidth = PlayerPrefs.GetFloat("ScreenWidth", 800);
		screenHeight = PlayerPrefs.GetFloat("ScreenHeight", 600);

		// Player Variables
		PlayerName = PlayerPrefs.GetString("userID", "");
		PlayerGoldG = PlayerPrefs.GetInt("Gold", 100);

		//Stage level determine how far the player progress in the game
		stageLevel = PlayerPrefs.GetInt("Stage",1);
	}
	// Use this for initialization
	void Start () 
    {
        // Player Variables
        PlayerName = PlayerPrefs.GetString("userID", "");

		//set to true and it will run tutorial
		runTutorial = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// add the x value of certain position
	// Parameter : Vector3 , float
	// Vector3 should be which vector3 you want to add
	// float should be how much value you want to add
	public static void AddPositionX(Vector3 position, float valueToAdd)
	{
		Vector3 temp = new Vector3 (valueToAdd + position.x, position.y, position.y);
		position = temp;
	}

	// add the y value of certain position
	// Parameter : Vector3 , float
	// Vector3 should be which vector3 you want to add
	// float should be how much value you want to add
	public static void AddPositionY(Vector3 position, float valueToAdd)
	{
		Vector3 temp = new Vector3 (position.x, position.y + valueToAdd, position.y);
		position = temp;
	}

    public static float GetScreenWidth()
    {
        return Screen.width;
    }

    public static void SetScreenWidth(float newWidth)
    {
        screenWidth = newWidth;
    }

    public static float GetScreenHeight()
    {
        return Screen.height;
    }

    public static void SetScreenHeight(float newHeight)
    {
        screenHeight = newHeight;
    }

    public static string GetPlayerName()
    {
        return PlayerName;
    }

    public static void SetPlayerName(string newName)
    {
        PlayerName = newName;
    }

    public static int GetPlayerGold()
    {
        return PlayerPrefs.GetInt("Gold", 100);
    }

    public static void SetPlayerGold(int newGold)
    {
        PlayerPrefs.SetInt("Gold", newGold);
    }

    public static void AddPlayerGold(int newGold)
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold", 100) + newGold);
    }

    public static void DecreasePlayerGold(int newGold)
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - newGold);
    }
		
	public static void SetStageLevel(int newStageLevel)
	{
		stageLevel = newStageLevel;
	}
	public static int GetStageLevel()
	{
		return stageLevel;
	}

	public static void SetPlayerHeroID(int slot,int id, bool active)
	{
        if (active)
        {
            switch (slot)
            {
                case 1:
                    PlayerPrefs.SetInt("Hero ID_1", id);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Hero ID_2", id);
                    break;
                case 3:
                    PlayerPrefs.SetInt("Hero ID_3", id);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (slot)
            {
                case 1:
                    PlayerPrefs.SetInt("Inactive Hero ID_1", id);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Inactive Hero ID_2", id);
                    break;
                case 3:
                    PlayerPrefs.SetInt("Inactive Hero ID_3", id);
                    break;
                default:
                    break;
            }
        }
	}

	public static int GetPlayerHeroID(int slot)
	{
		switch (slot)
        {
            case 1:
                return PlayerPrefs.GetInt("Hero ID_1", 1);
            case 2:
                return PlayerPrefs.GetInt("Hero ID_2", 2);
            case 3:
                return PlayerPrefs.GetInt("Hero ID_3", 3);
            default:
                Debug.Log("GetPlayerHeroID Invalid Parameter: returned 0");
                return 0;
        }
	}

    public static int GetInactiveHeroID(int slot)
    {
        switch (slot)
        {
            case 1:
                return PlayerPrefs.GetInt("Inactive Hero ID_1", 1);
            case 2:
                return PlayerPrefs.GetInt("Inactive Hero ID_2", 2);
            case 3:
                return PlayerPrefs.GetInt("Inactive Hero ID_3", 3);
            default:
                Debug.Log("GetPlayerHeroID Invalid Parameter: returned 0");
                return 0;
        }
    }

    public static GameObject GetHero(int id)
    {
        GameObject tempHero;
        switch (id)
        {
            case 1:
                tempHero = GameObject.Find("Cloud");
                return tempHero;
            case 2:
                tempHero = GameObject.Find("Weeb");
              return tempHero;
            case 3:
                tempHero = GameObject.Find("Werewolf");
                return tempHero;
            case 4:
                tempHero = GameObject.Find("Reaper");
                return tempHero;
            case 5:
                tempHero = GameObject.Find("Brawler");
                return tempHero;
            case 6:
                tempHero = GameObject.Find("Crimson_Knight");
                return tempHero;
            default:
                tempHero = null;
                Debug.Log("GetPlayerHero Invalid Parameter: returned null GameObject");
                return tempHero;
        }
    }

    public static GameObject GetPlayerHero(int slot)
    {
        GameObject tempHero;
        switch (slot)
        {
            case 1:
                return tempHero = GetHero(PlayerPrefs.GetInt("Hero ID_1", 1));
            case 2:
                return tempHero = GetHero(PlayerPrefs.GetInt("Hero ID_2", 2));
            case 3:
                return tempHero = GetHero(PlayerPrefs.GetInt("Hero ID_3", 3));
            default:
                tempHero = null;
                Debug.Log("GetPlayerHero Invalid Parameter: returned null GameObject");
                return tempHero;
        }
    }

    public static GameObject GetInactiveHero(int slot)
    {
        GameObject tempHero;
        switch (slot)
        {
            case 1:
                return tempHero = GetHero(PlayerPrefs.GetInt("Inactive Hero ID_1", 1));
            case 2:
                return tempHero = GetHero(PlayerPrefs.GetInt("Inactive Hero ID_2", 2));
            case 3:
                return tempHero = GetHero(PlayerPrefs.GetInt("Inactive Hero ID_3", 3));
            default:
                tempHero = null;
                Debug.Log("GetPlayerHero Invalid Parameter: returned null GameObject");
                return tempHero;
        }
    }

    public static string PrintPlayerHeroStats(int slot)
    {
        if (slot != 1 && slot != 2 && slot != 3)
        {
            Debug.Log("PrintPlayerHeroStats Invalid Parameter: returned null GameObject");
            return null;
        }
        else
            return GetPlayerHero(slot).GetComponent<Hero>().Get_HeroName() + "\nLevel: " + GetPlayerHero(slot).GetComponent<Hero>().Get_Level() + ", EXP: " + ((int)GetPlayerHero(slot).GetComponent<Hero>().Get_Exp()) + "/" + GetPlayerHero(slot).GetComponent<Hero>().Get_MaxExp() + "\nHP: " + GetPlayerHero(slot).GetComponent<Hero>().Get_MaxHp() + "\nAttack: " + GetPlayerHero(slot).GetComponent<Hero>().GetAttack() + "\nDefense: " + GetPlayerHero(slot).GetComponent<Hero>().GetDefense() + "\nSkill: " + GetPlayerHero(slot).GetComponent<Hero>().Get_Skill_Description();
    }

    public static string PrintHeroStats(int id)
    {
        if (id < 1 || id > 6)
        {
            Debug.Log("PrintPlayerHeroStats Invalid Parameter: returned null GameObject");
            return null;
        }
        else
            return GetHero(id).GetComponent<Hero>().Get_HeroName() + "\nLevel: " + GetHero(id).GetComponent<Hero>().Get_Level() + ", EXP: " + ((int)GetHero(id).GetComponent<Hero>().Get_Exp()) + "/" + GetHero(id).GetComponent<Hero>().Get_MaxExp() + "\nHP: " + GetHero(id).GetComponent<Hero>().Get_MaxHp() + "\nAttack: " + GetHero(id).GetComponent<Hero>().GetAttack() + "\nDefense: " + GetHero(id).GetComponent<Hero>().GetDefense() + "\nSkill: " + GetHero(id).GetComponent<Hero>().Get_Skill_Description();
    }

	public static bool GetRunTutorial()
	{
		return runTutorial;
	}

	public static void SetRunTutorial(bool newBool)
	{
		runTutorial = newBool;
	}
}
