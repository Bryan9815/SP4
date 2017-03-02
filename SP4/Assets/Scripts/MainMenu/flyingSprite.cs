using UnityEngine;
using System.Collections;

public class flyingSprite : MonoBehaviour 
{
	private float flyingSpeed;
	private Vector3 destination;
	private float movetowards;
	private float destinationX;
	private int screenWidth;

	// Use this for initialization
	void Start ()
	{
		if (transform.localPosition.x > 0.0f) 
		{
			destinationX = -GlobalVariable.GetScreenWidth () / 2;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			destinationX = GlobalVariable.GetScreenWidth () / 2;
		}
		flyingSpeed = 1.0f;
		destination = new Vector3 (destinationX, transform.localPosition.y, transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		movetowards = flyingSpeed * Time.deltaTime;
		//Right going left < 0.0f means it is spawn at left side of the screen
		if (transform.localPosition.x > destination.x && destinationX < 0.0f) {
			transform.Translate (Vector3.left * movetowards);
			if (transform.localPosition.x < destinationX)
				Destroy (this.gameObject);
		}
		//Left going right, > 0.0f means it is spawn at right side of the screen
		else if (transform.localPosition.x < destination.x && destinationX > 0.0f)
		{
			transform.Translate (Vector3.right * movetowards);
			if (transform.localPosition.x > destinationX)
				Destroy (this.gameObject);
		}
	}
}
