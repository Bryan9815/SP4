using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {
    public static int playerGold;
    public Text GoldText;
    public Button goldButton;
    void start()
    {
    }
	// Update is called once per frame
	void Update () 
    {
        playerGold = GlobalVariable.GetPlayerGold();
        GoldText.text = "$" + playerGold; 
	}

    public void buttonPressed()
    {
        playerGold += 1000;
        PlayerPrefs.SetInt("Gold", playerGold);
    }
}
