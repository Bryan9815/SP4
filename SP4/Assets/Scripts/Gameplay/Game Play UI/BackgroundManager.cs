using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{

    public GameObject[] bg;
	public GameObject[] bg2;
	public GameObject[] bg3;

	private float movetowards;
	public  float movingSpeed;
	private RectTransform rt_bg;

	//For moving the bg upwards
	private float tempY;
	private GameObject[] tempHolder;

	private int randomBGSet;

	// Use this for initialization
	void Start ()
    {
		tempY = 0.0f;
		randomBGSet = Random.Range (0, 3);
		if (movingSpeed < 0.0f)
			movingSpeed = 0.0f;
		
		switch (randomBGSet) 
		{
			case 0:
				tempHolder = bg;
			break;

			case 1:
				tempHolder = bg2;
			break;

			case 2:
				tempHolder = bg3;
			break;
		}
		for (int i = 0; i < tempHolder.Length; i++) 
		{
			rt_bg = tempHolder [i].GetComponent<RectTransform> ();
			tempHolder [i].GetComponent<RectTransform>().anchoredPosition = new Vector3 (rt_bg.rect.width * i, tempY, 0.1f * i);
		}

	}
	
	// Update is called once per frame
	void Update ()
    {
		movetowards = movingSpeed * Time.deltaTime;
	
		for (int i = 0; i < tempHolder.Length; i++) 
		{
			tempHolder [i].transform.Translate (Vector3.left * movetowards);
			if (tempHolder [i].GetComponent<RectTransform> ().anchoredPosition.x < -rt_bg.rect.width)
			{
				if(i == 0)
					tempHolder [i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (tempHolder[tempHolder.Length - 1].GetComponent<RectTransform>().anchoredPosition.x + rt_bg.rect.width - movingSpeed, 0.0f, 1.0f * i);
				else		
					tempHolder [i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (tempHolder[i-1].GetComponent<RectTransform>().anchoredPosition.x + rt_bg.rect.width, 0.0f, 1.0f * i);
			}
		}
			
	}
}
