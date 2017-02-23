using UnityEngine;
using System.Collections;

public class DamageText : MonoBehaviour 
{
	private float floatingSpeed;
	private Vector3 destination;

	private bool canFade;
	private Color alphaColor;
	private float fadingSpeed;


	// Use this for initialization
	void Start () 
	{
		floatingSpeed = 1.0f;
		destination = new Vector3 (transform.position.x, transform.position.y + 2.0f, transform.position.z);

		canFade = false;
		alphaColor.a = 1.0f;
		fadingSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float movetowards = floatingSpeed * Time.deltaTime;

		if (transform.position.y < destination.y) {                        
			alphaColor.a -= fadingSpeed * Time.deltaTime;
			transform.Translate (Vector3.up * movetowards);
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (gameObject.GetComponent<SpriteRenderer> ().color.r,
				gameObject.GetComponent<SpriteRenderer> ().color.b,
				gameObject.GetComponent<SpriteRenderer> ().color.g,
				alphaColor.a);
		} else {
			Destroy (this.gameObject);
		}
	}
}
