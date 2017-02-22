using UnityEngine;
using System.Collections;

public class Orc : Mob 
{
    enum States
    {
        Idle,
        Run,
    }
    States state;

	// Use this for initialization
	void Start () 
    {
        Hp = 10;
        Defense = 10;

        position.x = (float)(Random.Range(Screen.width, Screen.width * 3));
        state = States.Idle;
	}

	// Update is called once per frame
	void Update () 
    {
        switch(state)
        {
            case States.Idle:
                foreach (GameObject hero in HeroList)
                {
                    if(!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<BoxCollider2D>()))
                    {

                    }
                }
                break;
            default:
                break;
        }
	}
}
