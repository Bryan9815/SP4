using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Windows : MonoBehaviour 
{
    public Slider SFX, Music;
    public Button WindowMode_Left, WindowMode_Right, Resolution_Left, Resolution_Right, EraseData, ReturnToMainMenu;
    public Text SFX_Text, Music_Text, WindowMode, Resolution_Text;

    int windowMode, Resolution;
	// Use this for initialization
	void Start () 
    {
        windowMode = PlayerPrefs.GetInt("winMode", 0);
        Resolution = PlayerPrefs.GetInt("Resolution", 0);
        SFX.value = PlayerPrefs.GetFloat("SFX", 100);
        Music.value = PlayerPrefs.GetFloat("Music", 100);

        UpdateWindow();

        // Buttons
        WindowMode_Left.onClick.AddListener(delegate { if (windowMode > 0)windowMode--; UpdateWindow(); });
        WindowMode_Right.onClick.AddListener(delegate { if (windowMode < 1)windowMode++; UpdateWindow(); });
        Resolution_Left.onClick.AddListener(delegate { if (Resolution > 0)Resolution--; UpdateWindow(); });
        Resolution_Right.onClick.AddListener(delegate { if (Resolution < 5)Resolution++; UpdateWindow(); });
        EraseData.onClick.AddListener(delegate { EraseAllData(); });
        ReturnToMainMenu.onClick.AddListener(delegate { BackToMainMenu(); });
	}
	
	// Update is called once per frame
	void Update () 
    {
        SFX_Text.text = SFX.value.ToString();
        Music_Text.text = Music.value.ToString();
	}

    void UpdateWindow()
    {
        if(Resolution == 0)
        {
            Resolution_Text.text = "   800 x 600";
            GlobalVariable.SetScreenWidth(800);
            GlobalVariable.SetScreenHeight(600); 
            if (windowMode == 0)
            {
                Screen.SetResolution(800, 600, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(800, 600, false);
                WindowMode.text = "Windowed";
            }
        }
        else if(Resolution == 1)
        {
            Resolution_Text.text = "  1024 x 720";
            GlobalVariable.SetScreenWidth(1024);
            GlobalVariable.SetScreenHeight(720);
            if (windowMode == 0)
            {
                Screen.SetResolution(1024, 720, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(1024, 720, false);
                WindowMode.text = "Windowed";
            }
        }
        else if (Resolution == 2)
        {
            Resolution_Text.text = "  1440 x 810";
            GlobalVariable.SetScreenWidth(1440);
            GlobalVariable.SetScreenHeight(810);
            if (windowMode == 0)
            {
                Screen.SetResolution(1440, 810, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(1440, 810, false);
                WindowMode.text = "Windowed";
            }
        }
        else if (Resolution == 3)
        {
            Resolution_Text.text = "  1600 x 900";
            GlobalVariable.SetScreenWidth(1600);
            GlobalVariable.SetScreenHeight(900);
            if (windowMode == 0)
            {
                Screen.SetResolution(1600, 900, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(1600, 900, false);
                WindowMode.text = "Windowed";
            }
        }
        else if (Resolution == 4)
        {
            Resolution_Text.text = " 1600 x 1024";
            GlobalVariable.SetScreenWidth(1600);
            GlobalVariable.SetScreenHeight(1024);
            if (windowMode == 0)
            {
                Screen.SetResolution(1600, 1024, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(1600, 1024, false);
                WindowMode.text = "Windowed";
            }
        }
        else if (Resolution == 5)
        {
            Resolution_Text.text = " 1920 x 1080";
            GlobalVariable.SetScreenWidth(1920);
            GlobalVariable.SetScreenHeight(1080);
            if (windowMode == 0)
            {
                Screen.SetResolution(1920, 1080, true);
                WindowMode.text = "Fullscreen";
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
                WindowMode.text = "Windowed";
            }
        }
    }

    public void EraseAllData()
    {
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat("ScreenWidth", 800);
        //PlayerPrefs.SetFloat("ScreenHeight", 600);
        windowMode = PlayerPrefs.GetInt("winMode", 0);
        Resolution = PlayerPrefs.GetInt("Resolution", 0);
        SFX.value = PlayerPrefs.GetFloat("SFX", 100);
        Music.value = PlayerPrefs.GetFloat("Music", 100);
        UpdateWindow();
    }

    void BackToMainMenu()
    {
        PlayerPrefs.SetInt("winMode", windowMode);
        PlayerPrefs.SetInt("Resolution", Resolution);
        PlayerPrefs.SetFloat("SFX", SFX.value);
        PlayerPrefs.SetFloat("Music", Music.value);
        PlayerPrefs.SetFloat("ScreenWidth", GlobalVariable.GetScreenWidth());
        PlayerPrefs.SetFloat("ScreenHeight", GlobalVariable.GetScreenHeight());

        SceneManager.LoadScene("MainMenu");
    }
}
