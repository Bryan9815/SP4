using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Town : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
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
