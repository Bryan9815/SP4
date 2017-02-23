using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{

    public GameObject[] bg;
	private float movetowards;
	public  float movingSpeed;
	private RectTransform rt_bg;

	// Use this for initialization
	void Start ()
    {
		if (movingSpeed < 0.0f)
			movingSpeed = 0.0f;
		for (int i = 0; i < bg.Length; i++) 
		{
			rt_bg = bg [i].GetComponent<RectTransform> ();
			bg [i].GetComponent<RectTransform>().anchoredPosition = new Vector3 (rt_bg.rect.width * i, 0.0f, 0.1f * i);
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		movetowards = movingSpeed * Time.deltaTime;

		for (int i = 0; i < bg.Length; i++) 
		{
			bg [i].transform.Translate (Vector3.left * movetowards);
			if (bg [i].GetComponent<RectTransform> ().anchoredPosition.x < -rt_bg.rect.width)
			{
				if(i == 0)
					bg [i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (bg[bg.Length - 1].GetComponent<RectTransform>().anchoredPosition.x + rt_bg.rect.width - movingSpeed, 0.0f, 1.0f * i);
				else		
					bg [i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (bg[i-1].GetComponent<RectTransform>().anchoredPosition.x + rt_bg.rect.width, 0.0f, 1.0f * i);
			}
		}
	}
}
