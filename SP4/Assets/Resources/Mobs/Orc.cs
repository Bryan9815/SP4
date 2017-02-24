﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orc : Mob 
{
    enum States
    {
        Idle,
        Run,
    }
    States state;
    Animator animator;
	// Use this for initialization
	void Start () 
    {
        Hp = 10;
        Attack = 10;
        Defense = 10;
        goldValue = Random.Range(1, 10);
        state = States.Idle;
        animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x) + (gameObject.transform.position.y + Hero1.transform.position.y) * (gameObject.transform.position.y + Hero1.transform.position.y));
        // State Transitions
        if (distFromHero <= 7.5)
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
            Exit();
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
                        temp.x -= Time.deltaTime * 10;
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
                    else
                    {
                        //if (attackTimer > attackTimer_Max)
                        //{
                        //    hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                        //    attackTimer = 0;
                        //}
                        Exit();
                    }
                }
                break;
            default:
                break;
        }
	}
}
