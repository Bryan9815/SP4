using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalVariable : MonoBehaviour {

    private static float screenWidth;
    private static float screenHeight;
    private static string PlayerName;
    private static int PlayerGoldG;

	//Indicates the max number of wave per level
	private static int maxWaveNumber;

	//Determine which wave the player is in
	private static int currWaveNumber;

	//Indicates how far the player is in
	private static int stageLevel;

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

		//Max wave number is 5, so it means every 5 wave completed
		//means 1 level increase to state level
		maxWaveNumber = 5;

		//Current Wave number for indicating which wave the player is in
		currWaveNumber = PlayerPrefs.GetInt("Wave", 1);

		//Stage level determine how far the player progress in the game
		stageLevel = PlayerPrefs.GetInt("Stage",1);
	}
	// Use this for initialization
	void Start () 
    {

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

	public static void SetWaveNumber(int newWave)
	{
		currWaveNumber = newWave;
	}

	public static int GetWaveNumber()
	{
		return currWaveNumber;
	}

	public static void SetMaxWaveNumber(int newMaxWave)
	{
		maxWaveNumber = newMaxWave;
	}

	public static int GetMaxWaveNumber()
	{
		return maxWaveNumber;
	}

	public static void SetStageLevel(int newStageLevel)
	{
		stageLevel = newStageLevel;
	}
	public static int GetStageLevel()
	{
		return stageLevel;
	}

	//For saving
	public void SaveAllData()
	{
		PlayerPrefs.SetInt ("Wave", currWaveNumber);
		PlayerPrefs.SetInt ("Stage", stageLevel);
		PlayerPrefs.SetInt ("PlayerGold", PlayerGoldG);
		PlayerPrefs.SetString ("PlayerName", PlayerName);
		Debug.Log ("Wave = " + currWaveNumber);
		Debug.Log ("Stage = " + stageLevel);
		Debug.Log ("PlayerGold = " + PlayerGoldG);
		Debug.Log ("PlayerName = " + PlayerName);
		Debug.Log ("Saved all information, wave, stage, player's gold andp layer's name");
	}
}
