using UnityEngine;
using System.Collections;

public class ProgressBall : MonoBehaviour 
{
	private bool ableToMove;
	private Vector3 startPos;
	private int nextmobCount;
	private float speed;
	public GameObject endpoint;

	// Use this for initialization
	void Start () 
	{
		ableToMove = true;
		speed = 0.5f;
		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (WaveManager.ListOfMobs.Count <= 0)
			gameObject.transform.position = startPos;
		else
			speed = (endpoint.transform.localPosition.x - gameObject.transform.localPosition.x) / WaveManager.ListOfMobs.Count;
		
		if(ableToMove)
			gameObject.transform.Translate (Vector3.right * Time.deltaTime * speed);

	}

	void OnCollisionExit2D()
	{
		ableToMove = true;
	}

	void OnCollisionEnter2D()
	{
		ableToMove = false;
	}
}
