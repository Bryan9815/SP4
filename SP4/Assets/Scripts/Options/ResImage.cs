using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResImage : MonoBehaviour {

	public Sprite potatocom,win98, firstworldprob,goodguygreg,williywonka,feelsgood;
	Sprite currImage;
	// Use this for initialization
	void Start () {
		currImage = potatocom;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetResImage(int resolutionindex)
	{
		switch(resolutionindex)
		{
		case 0:
			currImage = potatocom;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;
		case 1:
			currImage = win98;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;
		case 2:
			currImage = firstworldprob;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;
		case 3:
			currImage = goodguygreg;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;
		case 4:
			currImage = williywonka;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;
		case 5:
			currImage = feelsgood;
			gameObject.GetComponent<Image> ().sprite = currImage;
			break;

		}
	}
}
