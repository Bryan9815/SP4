using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour 
{
    bool openTheShop = false, openTheUpgrade = false, openTheEquipment;
    public ToggleGroup UnBoughtHeroes, upgradeHeroes;
    public Button buyButton, upgradeButton;
    private Toggle buyToggleActive, upgradeToggleActive;
    public Canvas buyCanvas, upgradePanel;
    public Toggle toggle1, toggle2, toggle3;
    public Text CostToBuyHero, CostToUpgradeHero;
    int buyCost, upgradeCost;
    bool backtotownB = false;
    float timer = 1.0f;
	// Use this for initialization
	void Start ()
    {
        buyCost = PlayerPrefs.GetInt("Cost of Hero", 1000);    
        buyButton.onClick.AddListener(delegate
        {
            GlobalVariable.DecreasePlayerGold(buyCost);
            buyToggleActive.GetComponent<HeroSelector>().Get_GameObject().GetComponent<Hero>().Set_Unlocked(true);
            buyToggleActive.GetComponent<HeroSelector>().ActiveHeroUnselected();
            buyToggleActive.isOn = false;
            buyToggleActive.interactable = false;
            buyButton.interactable = false;
            buyToggleActive = null;
            buyCost += 100;
            PlayerPrefs.SetInt("Cost of Hero", buyCost);
        });
        upgradeButton.onClick.AddListener(delegate
        {
            GlobalVariable.DecreasePlayerGold(upgradeCost);
            upgradeToggleActive.GetComponent<HeroSelector>().Get_GameObject().GetComponent<Hero>().LevelUp();
        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        buySpecificHero();
        if(buyToggleActive)
        {
            if ((GlobalVariable.GetPlayerGold() < buyCost && buyToggleActive.isOn == false) || (GlobalVariable.GetPlayerGold() - buyCost) < 0)
            {
                buyButton.interactable = false;
            }
            else if (GlobalVariable.GetPlayerGold() >= buyCost)
            {
                buyButton.interactable = true;
            }
        }
        upgradeSpecificHero();
        if (upgradeToggleActive)
        {
            if ((GlobalVariable.GetPlayerGold() < upgradeCost && upgradeToggleActive.isOn == false) || (GlobalVariable.GetPlayerGold() - upgradeCost) < 0)
            {
                upgradeButton.interactable = false;
            }
            else if (GlobalVariable.GetPlayerGold() >= upgradeCost)
            {
                upgradeButton.interactable = true;
            }
        }

        displaySpecific(CostToBuyHero, buyCost.ToString());
        displaySpecific(CostToUpgradeHero, upgradeCost.ToString());

        if(backtotownB)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                SceneManager.LoadScene("Town");
        }
	}

    public void buySpecificHero()
    {
        if (!buyToggleActive)
        {
            buyToggleActive = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        }
        else if (buyToggleActive)
        {
            buyToggleActive.GetComponent<HeroSelector>().ActiveHeroSelected();
            if (!buyToggleActive.isOn)
            {
                buyButton.interactable = false;
                buyToggleActive.GetComponent<HeroSelector>().ActiveHeroUnselected();
                buyToggleActive = null;
            }
        }
    }

    public void upgradeSpecificHero()
    {
        if(!upgradeToggleActive)
        {
            upgradeToggleActive = ToggleGroupExtension.GetActive(upgradeHeroes);
        }
        else if(upgradeToggleActive)
        {
            upgradeCost = 50 * (upgradeToggleActive.GetComponent<HeroSelector>().Get_GameObject().GetComponent<Hero>().Get_Level() + 1);
            upgradeToggleActive.GetComponent<HeroSelector>().ActiveHeroSelected();
            if (!upgradeToggleActive.isOn)
            {
                upgradeButton.interactable = false;
                upgradeToggleActive.GetComponent<HeroSelector>().ActiveHeroUnselected();
                upgradeToggleActive = null;
            }
        }
    }

    public void OpenUpgrade()
    {
        if (!openTheUpgrade)
        {
            openTheUpgrade = true;
            upgradePanel.enabled = true;
        }
        if(openTheShop)
        {
            CloseShop();
        }
    }
    public void CloseUpgrade()
    {
        if (openTheUpgrade)
        {
            openTheUpgrade = false;
            upgradePanel.enabled = false;
        }
    }

    public void OpenShop()
    {
        if(!openTheShop)
        {
            openTheShop = true;
            buyCanvas.enabled = true;
        }
        if(openTheUpgrade)
        {
            CloseUpgrade();
        }
    }
    public void CloseShop()
    {   
        if(openTheShop)
        {
            openTheShop = false;
            buyCanvas.enabled = false;
        }
    }

    public void displaySpecific(Text display, string actualText)
    {
        display.text = "$" + actualText; 
    }

    void backToTown()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());

        backtotownB = true;
    }
}
