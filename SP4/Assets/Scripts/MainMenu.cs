using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public Button Play, Options;
	// Use this for initialization
	void Start () 
    {
        Play.onClick.AddListener(delegate { SceneManager.LoadScene("SaveMenu"); });
        Options.onClick.AddListener(delegate { SceneManager.LoadScene("OptionsMenu"); });
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
