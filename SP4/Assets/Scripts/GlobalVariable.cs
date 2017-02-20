using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GlobalVariable : MonoBehaviour {

    private static float screenWidth;
    private static float screenHeight;
    private static string PlayerName;
    private static int PlayerGoldG;
	private static List<int> PlayerActiveHeroes;
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

	// Use this for initialization
	void Start () 
    {
        screenWidth = PlayerPrefs.GetFloat("ScreenWidth", 800);
        screenHeight = PlayerPrefs.GetFloat("ScreenHeight", 600);

        // Player Variables
        PlayerName = PlayerPrefs.GetString("userID", "");
        PlayerGoldG = PlayerPrefs.GetInt("Gold", 100);

		PlayerActiveHeroes = new List<int> ();
		PlayerActiveHeroes.Add (1);
		PlayerActiveHeroes.Add (2);
		PlayerActiveHeroes.Add (3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static float GetScreenWidth()
    {
        return screenWidth;
    }
    public static void SetScreenWidth(float newWidth)
    {
        screenWidth = newWidth;
    }
    public static float GetScreenHeight()
    {
        return screenHeight;
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
        return PlayerGoldG;
    }
    public static void SetPlayerGold(int newGold)
    {
        PlayerGoldG = newGold;
    }

	public static void SetPlayerHeroID(int slot,int id)
	{
		PlayerActiveHeroes.Insert (slot, id);
	}

	public static int GetPlayerHeroID(int slot)
	{
		return PlayerActiveHeroes [slot];
	}
}
