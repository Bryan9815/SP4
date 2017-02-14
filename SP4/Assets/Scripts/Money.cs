using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {

    public static int gold = 100;
    public Text GoldText;
    public Button goldButton;
    void start()
    {

    }
	// Update is called once per frame
	void Update () 
    {
        GoldText.text = "$" + gold.ToString(); 
	}

    public void buttonPressed()
    {
        gold += 100;
    }
}
