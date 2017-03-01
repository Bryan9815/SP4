using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Mobile : MonoBehaviour
{
    public Slider SFX, Music;
    public Button EraseData, ReturnToMainMenu;
    public Toggle Vibration;
    public Text SFX_Text, Music_Text;
    bool dataErased;
    string playerName = "";

    int windowMode, Resolution;
    // Use this for initialization
    void Start()
    {
        dataErased = false;

        SFX.value = PlayerPrefs.GetFloat("SFX", 100);
        Music.value = PlayerPrefs.GetFloat("Music", 100);
        Vibration.isOn = BoolPrefs.GetBool("Vibration", true);

        // Buttons
        EraseData.onClick.AddListener(delegate { EraseAllData(); });
        ReturnToMainMenu.onClick.AddListener(delegate { BackToMainMenu(); });
    }

    // Update is called once per frame
    void Update()
    {
        SFX_Text.text = SFX.value.ToString();
        Music_Text.text = Music.value.ToString();

        if (dataErased)
        {
            SFX.interactable = false;
            Music.interactable = false;
            Vibration.interactable = false;
            EraseData.interactable = false;
            ReturnToMainMenu.interactable = false;
        }
        else
        {
            SFX.interactable = true;
            Music.interactable = true;
            Vibration.interactable = true;
            EraseData.interactable = true;
            ReturnToMainMenu.interactable = true;
        }
    }

    public void EraseAllData()
    {
        PlayerPrefs.DeleteAll();
        SFX.value = PlayerPrefs.GetFloat("SFX", 100);
        Music.value = PlayerPrefs.GetFloat("Music", 100);
        Vibration.isOn = BoolPrefs.GetBool("Vibration", true);

        dataErased = true;
    }

    void BackToMainMenu()
    {
        PlayerPrefs.SetFloat("SFX", SFX.value);
        PlayerPrefs.SetFloat("Music", Music.value);
        BoolPrefs.SetBool("Vibration", Vibration.isOn);

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
