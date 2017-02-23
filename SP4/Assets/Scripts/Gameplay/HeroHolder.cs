using UnityEngine;
using System.Collections;

public class HeroHolder : MonoBehaviour 
{

	public GameObject hero;
    public int HeroSlot;
    private float delayTimer;
	// Use this for initialization
	void Start () 
    {
        delayTimer = 0.0f;
        switch (HeroSlot)
        {
            case 0:
                Vector3 temp1 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
                hero.GetComponent<Hero>().transform.position = temp1;
                break;
            case 1:
                Vector3 temp2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
                hero.GetComponent<Hero>().transform.position = temp2;
                break;
            case 2:
                Vector3 temp3 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
                hero.GetComponent<Hero>().transform.position = temp3;
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (delayTimer < 3)
            delayTimer += Time.deltaTime;
        else
            hero.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        if(hero.GetComponent<Hero>().transform.position.x != gameObject.transform.position.x)
        {
            Vector3 temp = new Vector3(gameObject.transform.position.x, hero.GetComponent<Hero>().transform.position.y, 1);
            hero.GetComponent<Hero>().transform.position = temp;
        }
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
