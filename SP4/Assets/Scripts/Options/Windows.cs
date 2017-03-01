using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Windows : MonoBehaviour 
{
    public Slider SFX, Music;
    public Button WindowMode_Left, WindowMode_Right, Resolution_Left, Resolution_Right, EraseData, ReturnToMainMenu;
    public Text SFX_Text, Music_Text, WindowMode, Resolution_Text;
    bool dataErased;
    string playerName = "";

    int windowMode, Resolution;
	// Use this for initialization
	void Start () 
    {
        dataErased = false;

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

        if(dataErased)
        {
            SFX.interactable = false;
            Music.interactable = false;
            WindowMode_Left.interactable = false;
            WindowMode_Right.interactable = false;
            Resolution_Left.interactable = false;
            Resolution_Right.interactable = false;
            EraseData.interactable = false;
            ReturnToMainMenu.interactable = false;
        }
        else
        {
            SFX.interactable = true;
            Music.interactable = true;
            WindowMode_Left.interactable = true;
            WindowMode_Right.interactable = true;
            Resolution_Left.interactable = true;
            Resolution_Right.interactable = true;
            EraseData.interactable = true;
            ReturnToMainMenu.interactable = true;
        }
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
        windowMode = PlayerPrefs.GetInt("winMode", 0);
        Resolution = PlayerPrefs.GetInt("Resolution", 0);
        SFX.value = PlayerPrefs.GetFloat("SFX", 100);
        Music.value = PlayerPrefs.GetFloat("Music", 100);
        UpdateWindow();

        dataErased = true;
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

    void OnGUI()
    {
        if (dataErased)
        {
            float width = Screen.width * 0.3f;  // Make this wider to add more columns
            float height = Screen.height * 0.3f;
            GUILayoutOption[] layout = new GUILayoutOption[] { GUILayout.Width(width / 2.8f) };

            Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2), width, height * 0.2f);
            GUILayout.BeginArea(r, new GUIStyle("box"));

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Enter Your Name: ");
            this.playerName = GUILayout.TextField(this.playerName, layout);

            if (GUILayout.Button("Ok"))
            {
                if (playerName == "")
                {
                    GUILayout.Label("Invalid name, please try again.");
                    return;
                }
                PlayerPrefs.SetString("userID", playerName);

                dataErased = false;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
