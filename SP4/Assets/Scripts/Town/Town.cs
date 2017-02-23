using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Town : MonoBehaviour {
    bool started = false;
    public Canvas displayMode;
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
    public void OpenMode()
    {
        if (!started)
        {
            started = true;
            displayMode.enabled = true;
        }
    }
    public void CloseMode()
    {
        if (started)
        {
            started = false;
            displayMode.enabled = false;
        }
    }

    public void EndlessMode()
    {
        SceneManager.LoadScene("GamePlay");
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
