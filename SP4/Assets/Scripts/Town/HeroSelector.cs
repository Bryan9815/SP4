using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroSelector : MonoBehaviour 
{
    public Image heroSprite;
    public Text heroStatDisplay;
    public int HeroID, slot;
    private bool Active;

	// Use this for initialization
	void Start () 
    {
        if (gameObject.GetComponent<Toggle>().group.name == "Hero Slot 1")
            Active = true;
        else
            Active = false;

        if (Active)
        {
            switch (slot)
            {
                case 1:
                    HeroID = PlayerPrefs.GetInt("Hero ID_1", 1);
                    break;
                case 2:
                    HeroID = PlayerPrefs.GetInt("Hero ID_2", 2);
                    break;
                case 3:
                    HeroID = PlayerPrefs.GetInt("Hero ID_3", 3);
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
                    HeroID = PlayerPrefs.GetInt("Inactive Hero ID_1", 4);
                    break;
                case 2:
                    HeroID = PlayerPrefs.GetInt("Inactive Hero ID_2", 5);
                    break;
                case 3:
                    HeroID = PlayerPrefs.GetInt("Inactive Hero ID_3", 6);
                    break;
                default:
                    break;
            }
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        heroSprite.sprite = GlobalVariable.GetHero(HeroID).GetComponent<Hero>().GetSprite();

        if (!Active)
            heroStatDisplay.text = GlobalVariable.PrintRecordHeroStats(HeroID);
    }
}
