using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalVariable : MonoBehaviour {

    private static float screenWidth;
    private static float screenHeight;

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
    //1st. Set to private
    //2nd. Set to static funtcion
    //3rd. Set the function you want
    //4th. Set Function Name

	// Use this for initialization
	void Start () {
        //Testing Purpose
        screenHeight = 100.0f;
        screenWidth = 100.0f;
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
}
