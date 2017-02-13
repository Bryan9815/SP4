using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    private float testfloat;
	// Use this for initialization
	void Start () 
    {
      testfloat = GlobalVariable.GetScreenHeight();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("TestFloat = " + testfloat);
	}
}
