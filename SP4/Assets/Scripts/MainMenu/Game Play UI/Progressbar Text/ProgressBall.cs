using UnityEngine;
using System.Collections;

public class ProgressBall : MonoBehaviour 
{
	private bool ableToMove;
	private int currWaveNum;
	private int prevWaveNum;
	private int maxWaveNum;
	// Use this for initialization
	void Start () 
	{
		ableToMove = true;
		prevWaveNum = 1;
		maxWaveNum = GlobalVariable.GetMaxWaveNumber();
	}
	
	// Update is called once per frame
	void Update () 
	{
		currWaveNum = GlobalVariable.GetWaveNumber ();
	
		if(ableToMove)
			gameObject.transform.Translate (Vector3.right * Time.deltaTime * 0.5f);

	}
	void OnCollisionExit2D()
	{
		ableToMove = true;
		if (prevWaveNum == GlobalVariable.GetMaxWaveNumber () - 1) {
			ableToMove = false;
		}
	}
	void OnCollisionEnter2D()
	{
		ableToMove = false;
		if (currWaveNum == GlobalVariable.GetMaxWaveNumber ())
			prevWaveNum = currWaveNum - 1;
	}
}
