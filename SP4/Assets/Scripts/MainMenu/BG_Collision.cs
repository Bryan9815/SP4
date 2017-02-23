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
		  #if UNITY_ANDROID
		   Touch myTouch = Input.GetTouch(0);
		   Vector3 touchPos = new Vector3 (myTouch.position.x, myTouch.position.y, 1);
			if(Input.GetTouch(0)
			{
				touchPos = myTouch.position;
				touchPos.z = 10;
				screenPos = cam.ScreenToWorldPoint (touchPos);
				RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);
				if (hit) 
				{
					if (hit.collider.gameObject.name == "town_background")
						Debug.Log ("hit mm");
					else if (hit.collider.gameObject.name == "options")
						Debug.Log ("hit options");
					else if (hit.collider.gameObject.name == "highscore")
						Debug.Log ("hit highscore");
					else if (hit.collider.gameObject.name == "quit")
						Debug.Log ("hit quit");
				}
				else
					Debug.Log ("Hit nothing");

			}
		  #else

			if (Input.GetMouseButtonDown (0))
			{
				touchPos = Input.mousePosition;
				touchPos.z = 10;
				screenPos = cam.ScreenToWorldPoint (touchPos);
				RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);
				if (hit) 
				{
					if (hit.collider.gameObject.name == "town_background")
						Debug.Log ("hit mm");
					else if (hit.collider.gameObject.name == "options")
						Debug.Log ("hit options");
					else if (hit.collider.gameObject.name == "highscore")
						Debug.Log ("hit highscore");
					else if (hit.collider.gameObject.name == "quit")
						Debug.Log ("hit quit");
				}
				else
					Debug.Log ("Hit nothing");

				
			}
		#endif
	}
		
}
