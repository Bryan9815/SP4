using UnityEngine;
using System.Collections;

public class HeroHolder : MonoBehaviour {

	public GameObject hero;
	public GameObject SpriteAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject Get_GameObject()
	{
		return hero;
	}

	public void Set_GameObject(GameObject newGameobject)
	{
		hero = newGameobject;
	}
}
