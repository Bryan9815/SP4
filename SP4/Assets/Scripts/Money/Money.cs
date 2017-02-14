using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {
    public int playerGold;
    public Text GoldText;
    public Button goldButton;
    void start()
    {
        playerGold = GlobalVariable.PlayerGoldG;
    }
	// Update is called once per frame
	void Update () 
    {
        GoldText.text = "$" + playerGold.ToString(); 
	}

    public void buttonPressed()
    {
        playerGold += 100;
    }
}
