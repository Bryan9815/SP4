using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressbarManager : MonoBehaviour 
{
	//just a text to display the ending point of the game
	public Text end;

	//this gameobject is used to display the progress of the player
	public GameObject progressbar;

	//this gameobject is used to stop movement of progress
	public GameObject endpoint;

	//the moving ball indicate the player's progress
	public GameObject progressBall;

	//Start position for the progressball
	private Vector3 startPosition;

	//distance between the start and end point
	private float distance;

	//distance per wave for the progress bar to move
	private float distancePerWave;

	//Just a copy of GlobalVariable max wave
	private int maxWavenum;

	//Just a copy of GlobalVariable current wave
	private int currWaveNum;
	  
	//Just a temp variable for setting the endpoint position
	private Vector3 tempEndpoint;

	// Use this for initialization
	void Start () 
	{
		maxWavenum = GlobalVariable.GetMaxWaveNumber();
		currWaveNum = GlobalVariable.GetWaveNumber();
		end.text = "End";
		distance = endpoint.transform.localPosition.x - progressBall.transform.localPosition.x;
		distancePerWave = distance / maxWavenum;
		startPosition = progressBall.transform.localPosition;
		tempEndpoint = new Vector3 ((distancePerWave * currWaveNum) + startPosition.x,
									 endpoint.transform.localPosition.y,
									 endpoint.transform.localPosition.z);
		
		//Turn the display off at the start
		//endpoint.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currWaveNum = GlobalVariable.GetWaveNumber();
		if (endpoint.transform.localPosition.x != (distancePerWave * currWaveNum) + startPosition.x) 
		{
			tempEndpoint.Set ((distancePerWave * currWaveNum) + startPosition.x, 
							  endpoint.transform.localPosition.y, 
							  endpoint.transform.localPosition.z);	
			endpoint.transform.localPosition = tempEndpoint;
		}
	}
}
