using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialOrc : Mob 
{
	enum States
	{
		Idle,
		Run,
		Death,
	}

	States state;
	Animator animator;

	// Use this for initialization
	protected override void Start() 
	{
		CalculateStats();
		goldValue = Random.Range(1, 10);

		attackTimer = 0.0f;
		attackTimer_Max = 2.0f;

		state = States.Idle;
		animator = GetComponent<Animator>();
	}

	void CalculateStats()
	{
		Hp = 10;
		Attack = 1;
		Defense = 1;
		exp = 0;
	}

	// Update is called once per frame
	protected override void Update() 
	{
		if (!Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
			distFromHero = Mathf.Sqrt(((float)(gameObject.transform.position.x - Hero1.transform.position.x) * (gameObject.transform.position.x - Hero1.transform.position.x)));
		else if (!Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
			distFromHero = Mathf.Sqrt(((float)(gameObject.transform.position.x - Hero2.transform.position.x) * (gameObject.transform.position.x - Hero2.transform.position.x)));
		else if (!Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
			distFromHero = Mathf.Sqrt(((float)(gameObject.transform.position.x - Hero3.transform.position.x) * (gameObject.transform.position.x - Hero3.transform.position.x)));

		// State Transitions
		if (distFromHero < 7.5)
		{
			state = States.Run;
			animator.SetTrigger("Run");
		}
		else
		{
			state = States.Idle;
			animator.SetTrigger("Idle");
		}
		if (Hp <= 0)
		{
			state = States.Death;
		}

		// States
		switch(state)
		{
		case States.Idle:
			foreach (GameObject hero in HeroList)
			{
				if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
				{
					Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
					temp.x -= Time.deltaTime * 0.8f;
					gameObject.transform.position = temp;
				}
			}
			break;
		case States.Run:
			foreach(GameObject hero in HeroList)
			{
				Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

				if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
				{
					temp.x -= Time.deltaTime;
					gameObject.transform.position = temp;
				}
			}
			break;
		case States.Death:
			Destroy (gameObject.GetComponent<BoxCollider2D> ());
			animator.enabled = false;
			if (gameObject.transform.position.y < -(Screen.height / 20)) 
			{
				gameObject.SetActive (false);
				TutorialManager.counter++;
			}
			break;
		default:
			break;
		}
	}
}
