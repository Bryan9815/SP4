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
    int l = 0;
    public Toggle toggle1, toggle2, toggle3, toggle4, toggle5;
    public Text costOfRNG, costOfSpecificHero;
    int RNGCost, SpecificCost;
    bool backtotownB = false;
    float timer = 1.0f;
	// Use this for initialization
	void Start ()
    {
        RNGCost = 100;
        SpecificCost = 1000;
        rngButton.onClick.AddListener(delegate
        {
            Money.playerGold -= RNGCost;
            l += 1;
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
            RandomToggle();
            if(tungle)
            {
                if (tungle && tungle.interactable == false)
                {
                    RandomToggle();
                }
                if (tungle && tungle.interactable == true)
                {
                    tungle.GetComponent<Hero>().unlocked = true;
                    tungle.interactable = false;
                }
            }
            else 
            {

            }
            RNGCost += 250;
            SpecificCost += 50;
        });

        buyButton.onClick.AddListener(delegate
        {
            l += 1;
            Money.playerGold -= SpecificCost;
            tungle.interactable = false;
            buyButton.interactable = false;
            Destroy(tungle);
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
            RNGCost += 250;
            SpecificCost += 50;
        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        RNGHero();
        buySpecificHero();
        if(tungle && tungle.interactable == false)
        {
            tungle.isOn = false;
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        }
        displayRNG();
        displaySpecific();

        if(backtotownB)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                SceneManager.LoadScene("Town");
        }
	}

    void RandomToggle()
    {
        do
        {
            float randomN = Random.Range(0.0f, 5.0f);
            if (randomN >= 0.0f && randomN < 1.0f)
            {
                tungle = toggle1;
                if (toggle1.IsDestroyed())
                {
                    RandomToggle();
                }
            }
            else if (randomN >= 1.0f && randomN < 2.0f)
            {
                tungle = toggle2;
                if(toggle2.IsDestroyed())
                {
                    RandomToggle();
                }
            }
            else if (randomN >= 2.0f && randomN < 3.0f)
            {
                tungle = toggle3;
                if (toggle3.IsDestroyed())
                {
                    RandomToggle();
                }
            }
            else if (randomN >= 3.0f && randomN < 4.0f)
            {
                tungle = toggle4;
                if (toggle4.IsDestroyed())
                {
                    RandomToggle();
                }
            }
            else if (randomN >= 4.0f && randomN < 5.0f)
            {
                tungle = toggle5;
                if (toggle5.IsDestroyed())
                {
                    RandomToggle();
                }
            }
            if(tungle.GetComponent<Hero>().unlocked == true)
            {

            }
        } while (tungle.IsInteractable() == false);
    }

    public void RNGHero()
    {
      if (Money.playerGold < 100 || l > 4)
      {
          rngButton.interactable = false;
      }
      else
      {
          rngButton.interactable = true;
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
            if (Money.playerGold < 1000 && tungle.isOn == false || l > 4)
            {
                buyButton.interactable = false;
            }
            else if (Money.playerGold >= 1000)
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

    public void displayRNG()
    {
        costOfRNG.text = "$" + RNGCost.ToString(); 
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
