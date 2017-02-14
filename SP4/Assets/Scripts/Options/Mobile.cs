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

    int windowMode, Resolution;
    // Use this for initialization
    void Start()
    {
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
    }

    public static void EraseAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    void BackToMainMenu()
    {
        PlayerPrefs.SetFloat("SFX", SFX.value);
        PlayerPrefs.SetFloat("Music", Music.value);
        BoolPrefs.SetBool("Vibration", Vibration.isOn);

        SceneManager.LoadScene("MainMenu");
    }
}
