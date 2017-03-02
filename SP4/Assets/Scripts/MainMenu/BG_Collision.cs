using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Collections;

public class BG_Collision : MonoBehaviour {

	public Camera cam;

	//RaycastHit2D hit;
	Vector3 touchPos;
	Vector3 screenPos;
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () 
	{
			if (Input.GetMouseButtonDown (0))
			{
				touchPos = Input.mousePosition;
				touchPos.z = 10;
				screenPos = cam.ScreenToWorldPoint (touchPos);
				RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);
				if (hit) 
				{
					if (hit.collider.gameObject.name == "town_background")
						SceneManager.LoadScene("Town");
					else if (hit.collider.gameObject.name == "options")
						SceneManager.LoadScene("Options_Window");
					else if (hit.collider.gameObject.name == "highscore")
						SceneManager.LoadScene("High Score");
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
        SceneManager.LoadScene("Options_Window");
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
