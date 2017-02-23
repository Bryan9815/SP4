using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour 
{
    bool openTheShop = false, openTheUpgrade = false;
    public ToggleGroup UnBoughtHeroes;
    public Button buyButton, rngButton;
    private Toggle tungle;
    public Canvas buyCanvas, upgradePanel;
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
            Money.playerGold -= SpecificCost;
            tungle.interactable = false;
            buyButton.interactable = false;
            Destroy(tungle);
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
            SpecificCost += 50;
        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        buySpecificHero();
        if(tungle && tungle.interactable == false)
        {
            tungle.isOn = false;
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        }
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
            if (Money.playerGold < SpecificCost && tungle.isOn == false)
            {
                buyButton.interactable = false;
            }
            else if (Money.playerGold >= SpecificCost)
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
