using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharSelect : MonoBehaviour {

    private AudioSource enterMenus;
    bool backtotownB = false;
    float timer = 1.0f;
	// Use this for initialization
	void Start () {

        enterMenus = GameObject.Find("EnterMenus").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        enterMenus.volume = PlayerPrefs.GetFloat("SFX") / 100; 
        if (backtotownB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                SceneManager.LoadScene("Town");
        }
	}

    public void backToTownAgain()
    {
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        enterMenus.Play();
        backtotownB = true;
    }
}
