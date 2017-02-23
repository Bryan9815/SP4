using UnityEngine;
using System.Collections;

public class HeroHolder : MonoBehaviour 
{

	public GameObject hero;
    public int HeroSlot;

	// Use this for initialization
	void Start () 
    {
        switch(HeroSlot)
        {
            case 0:
                Instantiate(hero, new Vector3(Screen.width / 10 * 3, Screen.height / 2, 1), hero.transform.rotation);
                hero.SetActive(true);
                break;
            case 1:
                Instantiate(hero, new Vector3(Screen.width / 10 * 2, Screen.height / 2, 1), hero.transform.rotation);
                hero.SetActive(true);
              break;
            case 2:
                Instantiate(hero, new Vector3(Screen.width / 10, Screen.height / 2, 1), hero.transform.rotation);
                hero.SetActive(true);
                break;
            default:
                break;
        }
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
