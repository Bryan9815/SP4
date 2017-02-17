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
	// Use this for initialization
	void Start ()
    {
        rngButton.onClick.AddListener(delegate
        {
            Money.playerGold -= 100;
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
        });

        buyButton.onClick.AddListener(delegate {
            Money.playerGold -= 1000;
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes); 
            tungle.interactable = false; 
        });
	}
	
	// Update is called once per frame
	void Update ()
    {
        RNGHero();
        buySpecificHero();
        if(tungle && tungle.interactable == false)
        {
            l += 1;
            tungle.isOn = false;
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
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
            }
            else if (randomN >= 1.0f && randomN < 2.0f)
            {
                tungle = toggle2;
            }
            else if (randomN >= 2.0f && randomN < 3.0f)
            {
                tungle = toggle3;
            }
            else if (randomN >= 3.0f && randomN < 4.0f)
            {
                tungle = toggle4;
            }
            else if (randomN >= 4.0f && randomN < 5.0f)
            {
                tungle = toggle5;
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
            tungle = ToggleGroupExtension.GetActive(UnBoughtHeroes);
        else if (tungle)
        {
            if (Money.playerGold < 1000)
            {
                buyButton.interactable = false;
            }
            else
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

    public void backToTown()
    {
        SceneManager.LoadScene("Town");
    }
}
