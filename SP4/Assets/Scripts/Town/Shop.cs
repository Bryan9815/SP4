using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shop : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void RNGHero()
    {
        if(Money.playerGold <= 100)
        {

        }
        else 
        { 
            Money.playerGold -= 100; 
        }
    }
    public void buySpecificHero()
    {
        if (Money.playerGold <= 1000)
        {

        }
        else
        {
            Money.playerGold -= 1000;
        }
    }

    public void backToTown()
    {
        SceneManager.LoadScene("Town");
    }
}
