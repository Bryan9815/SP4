using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour 
{
    bool openTheShop = false, openTheUpgrade = false, openTheEquipment;
    public ToggleGroup UnBoughtHeroes;
    public Button buyButton;
    private Toggle tungle;
    public Canvas buyCanvas, upgradePanel, equipCanvas;
    public Toggle toggle1, toggle2, toggle3;
    public Text costOfRNG, costOfSpecificHero;
    int SpecificCost;
    bool backtotownB = false;
    float timer = 1.0f;
	// Use this for initialization
	void Start ()
    {
        SpecificCost = 1000;    
        buyButton.onClick.AddListener(delegate
        {
            GlobalVariable.DecreasePlayerGold(SpecificCost);
            tungle.GetComponent<HeroSelector>().Get_GameObject().GetComponent<Hero>().Set_Unlocked(true);
            tungle.GetComponent<HeroSelector>().ActiveHeroUnselected();
            tungle.isOn = false;
            tungle.interactable = false;
            buyButton.interactable = false;
            tungle = null;
            SpecificCost += 50;
        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        buySpecificHero();
        if(tungle && !tungle.isOn)
        {
            tungle.isOn = false;
            tungle.GetComponent<HeroSelector>().ActiveHeroUnselected();
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        }
        else if (tungle && tungle.isOn)
            tungle.GetComponent<HeroSelector>().ActiveHeroSelected();
        displaySpecific();

        if(backtotownB)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                SceneManager.LoadScene("Town");
        }
	}

    public void buySpecificHero()
    {
        if (!tungle)
        {
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        }
        else if (tungle)
        {
            if (GlobalVariable.GetPlayerGold() < SpecificCost && tungle.isOn == false)
            {
                buyButton.interactable = false;
            }
            else if (GlobalVariable.GetPlayerGold() >= SpecificCost)
            {
                buyButton.interactable = true;
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

    public void OpenEquipment()
    {
        if (!openTheEquipment)
        {
            openTheEquipment = true;
            equipCanvas.enabled = true;
        }
        if (openTheEquipment)
        {
            CloseUpgrade();
        }
    }
    public void CloseEquipment()
    {
        if (openTheEquipment)
        {
            openTheEquipment = false;
            equipCanvas.enabled = false;
        }
    }

    public void displaySpecific()
    {
        costOfSpecificHero.text = "$" + SpecificCost.ToString(); 
    }

    void backToTown()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());

        backtotownB = true;
    }
}
