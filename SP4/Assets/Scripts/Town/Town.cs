using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Town : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToClear());
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void goToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToShop()
    {
        SceneManager.LoadScene("TownShop");
    }

    public void goToCharSelect()
    {
        SceneManager.LoadScene("SelectHeroes");
    }
}
