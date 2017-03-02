using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Town : MonoBehaviour {
    bool SeenTutorial;
    bool started = false;
    public Canvas displayMode;
    bool toShopB = false, toCharSelectB = false, toEndlessB = false, toTutorial = false;
    float timer = 1.0f;
    private static AudioSource ThatAudioSource;
    private AudioSource enterMenus;
	// Use this for initialization
	void Awake ()
    {
        SeenTutorial = BoolPrefs.GetBool("Seen Tutorial", false);
        ThatAudioSource = GameObject.Find("TownMusic").GetComponent<AudioSource>();
        enterMenus = GameObject.Find("EnterMenus").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ThatAudioSource.volume = PlayerPrefs.GetFloat("Music") / 100;
        enterMenus.volume = PlayerPrefs.GetFloat("SFX") / 100;
        if (!SeenTutorial)
        {
            SceneManager.LoadScene("TownTutorial");
        }

        ThatAudioSource.volume = PlayerPrefs.GetFloat("Music")/100;
        if (toShopB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("TownShop");
            }
        } 
        if (toCharSelectB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("SelectHeroes");
            }
        } 
        if (toEndlessB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("GamePlay");
            }
        }
        if (toTutorial)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
	   
	}
    public void OpenMode()
    {
        if (!started)
        {
            started = true;
            displayMode.enabled = true;
        }
    }
    public void CloseMode()
    {
        if (started)
        {
            started = false;
            displayMode.enabled = false;
        }
    }

    public void EndlessMode()
    {
        enterMenus.Play();
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        toEndlessB = true;
    }

    public void goToMain()
    {
        enterMenus.Play();
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        SceneManager.LoadScene("MainMenu");
    }

    public void goToShop()
    {
        enterMenus.Play();
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack()); 
        toShopB = true;
    }

    public void goToCharSelect()
    {
        enterMenus.Play();
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        toCharSelectB = true;
    }
    public void goToTutorial()
    {
        enterMenus.Play();
        AutoFade AF = GameObject.FindGameObjectWithTag("Fader").GetComponent<AutoFade>();
        StartCoroutine(AF.FadeToBlack());
        toTutorial = true;
    }
    public static AudioSource Get_AudioSource()
    {
        return ThatAudioSource;
    }
}
