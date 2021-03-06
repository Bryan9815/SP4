﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroSelector : MonoBehaviour 
{
    public Image heroSprite;
    public Text heroStatDisplay;
    public int HeroID, slot;
    public bool Active, Shop, Upgrade;
    private bool ImageSet = false;
	// Use this for initialization
	void Start () 
    {
        if (gameObject.GetComponent<Toggle>().group.name == "Hero Slot 1")
            Active = true;
        else if (!Shop && !Upgrade)
            Active = false;

        if (Active)
        {
            if (!Shop && !Upgrade)
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
                        HeroID = 1;
                        break;
                    case 2:
                        HeroID = 2;
                        break;
                    case 3:
                        HeroID = 3;
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            if (!Shop && !Upgrade)
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
            else
            {
                switch (slot)
                {
                    case 1:
                        HeroID = 4;
                        break;
                    case 2:
                        HeroID = 5;
                        break;
                    case 3:
                        HeroID = 6;
                        break;
                    default:
                        break;
                }
            }
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!ImageSet)
        {
            GlobalVariable.GetHero(HeroID).GetComponent<Hero>().Set_Static();
            ImageSet = true;
        }
        heroSprite.sprite = GlobalVariable.GetHero(HeroID).GetComponent<Hero>().GetSprite();

        if (!Active && !Shop && !Upgrade)
        {
            heroStatDisplay.text = GlobalVariable.PrintHeroStats(HeroID);
        }

        if (Shop)
        {
            if (GlobalVariable.GetHero(HeroID).GetComponent<Hero>().Get_Unlocked())
                gameObject.GetComponent<Toggle>().interactable = false;
        }
        else
            if (!GlobalVariable.GetHero(HeroID).GetComponent<Hero>().Get_Unlocked())
                gameObject.GetComponent<Toggle>().interactable = false;
            else
                gameObject.GetComponent<Toggle>().interactable = true;
    }

    public void ActiveHeroSelected()
    {
        heroStatDisplay.text = GlobalVariable.PrintHeroStats(HeroID);
    }

    public void ActiveHeroUnselected()
    {
        heroStatDisplay.text = "";
    }

    public GameObject Get_GameObject()
    {
        return GlobalVariable.GetHero(HeroID);
    }
}
