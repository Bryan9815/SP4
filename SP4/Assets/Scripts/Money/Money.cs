using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {
    public static int playerGold;
    public Text GoldText;
    public Button goldButton;
    void start()
    {
        playerGold = GlobalVariable.GetPlayerGold();
    }
	// Update is called once per frame
	void Update () 
    {
        GoldText.text = "$" + playerGold.ToString(); 
	}

    public void buttonPressed()
    {
        playerGold += 100;
        PlayerPrefs.SetInt("Gold", playerGold);
    }
}
