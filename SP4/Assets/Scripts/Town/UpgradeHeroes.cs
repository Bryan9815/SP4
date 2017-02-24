using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeHeroes : MonoBehaviour {
    public Button levelUPButton;
    Hero heroLeveling;
    protected static int costToLevelUp;
    bool ableToLevelUp = false;
	// Use this for initialization
	void Start () 
    {
        levelUPButton.onClick.AddListener(delegate 
        {
            heroLeveling = levelUPButton.GetComponent<Hero>();
            heroLeveling.LevelUp();
            Money.playerGold -= costToLevelUp;
        });
	}
	
	// Update is called once per frame
	void Update () 
    {
	    buyUpgrade();
	}

    void buyUpgrade()
    {
        costToLevelUp = 100;
        //costToLevelUp = ((heroLeveling.Get_Level() * 20)   + (((int)heroLeveling.GetAttack()) / 100)  + ((int)heroLeveling.GetDefense() / 100 ));
        if (Money.playerGold >= GetCost())
        {
            ableToLevelUp = true;
        }
        else
        {
            ableToLevelUp = false;
        }
        if (!ableToLevelUp)
        {
            levelUPButton.interactable = false;
        }
        if (ableToLevelUp)
        {
            levelUPButton.interactable = true;
        }
    }
    public static float GetCost()
    {
        return costToLevelUp;
    }
}
