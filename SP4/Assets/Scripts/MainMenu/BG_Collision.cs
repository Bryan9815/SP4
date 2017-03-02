using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Collections;

public class BG_Collision : MonoBehaviour {

	public Camera cam;

    private AudioSource enterMenus;
	//RaycastHit2D hit;
	Vector3 touchPos;
	Vector3 screenPos;
	// Use this for initialization
    void Awake()
    {
        enterMenus = GameObject.Find("Enter Menu").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
            enterMenus.volume = PlayerPrefs.GetFloat("SFX") / 100;
			if (Input.GetMouseButtonDown (0))
			{
				touchPos = Input.mousePosition;
				touchPos.z = 10;
				screenPos = cam.ScreenToWorldPoint (touchPos);
				RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);
				if (hit) 
				{
					if (hit.collider.gameObject.name == "town_background")
                    {
                        enterMenus.Play();
                        SceneManager.LoadScene("Town");
                    }
					else if (hit.collider.gameObject.name == "options")
                    {
                        SceneManager.LoadScene("Options_Window");
                    }
					else if (hit.collider.gameObject.name == "highscore")
                    {
                        enterMenus.Play();
                        SceneManager.LoadScene("High Score");
                    }
					else if (hit.collider.gameObject.name == "quit")
						Application.Quit();
				}
				else
					Debug.Log ("Hit nothing");

				
			}
	}
    public void GoToTown()
    {
        SceneManager.LoadScene("Town");
    }

    public void GoToOptions()
    {
        #if UNITY_ANDROID
                SceneManager.LoadScene("Options_Mobile");
        #else
                SceneManager.LoadScene("Options_Window");
        #endif
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene("High Score");
    }

    public void Quit()
    {
        Application.Quit();
    }
}