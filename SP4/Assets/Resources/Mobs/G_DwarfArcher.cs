﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class G_DwarfArcher : Mob
{
    enum States
    {
        Idle,
        Walk,
        Attack,
        Death,
    }
    States state;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        Hp = 10;
        Defense = 10;

        attackTimer = 5.0f;
        attackTimer_Max = 2.0f;

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x));
        if (distFromHero <= 7.5 && distFromHero > 5)
        {
            state = States.Walk;
            animator.SetTrigger("Target Detected");
        }
        else if(distFromHero > 7.5 && state != States.Attack)
        {
            state = States.Idle;
            animator.SetTrigger("No Targets");
        }
        else if (distFromHero <= 5)
        {
            state = States.Attack;
            animator.SetBool("Targets In Range", true);
        }
        Debug.Log("State: " + state.ToString());
        switch (state)
        {
            case States.Idle:
                if (!animator.GetBool("Targets In Range"))
                {
                    foreach (GameObject hero in HeroList)
                    {
                        if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                        {
                            Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                            temp.x -= Time.deltaTime;
                            gameObject.transform.position = temp;
                        }
                    }
                }
                //if(animator.GetBool("Targets In Range"))
                //{
                //    attackTimer += Time.deltaTime;
                //    if(attackTimer >= attackTimer_Max)
                //    {
                //        state = States.Attack;
                //    }
                //}
                break;
            case States.Walk:
                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime;
                        gameObject.transform.position = temp;
                    }
                }
                break;
            case States.Attack:
                attackTimer += Time.deltaTime;
                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime * 0.5f;
                        gameObject.transform.position = temp;

                        if (attackTimer >= attackTimer_Max)
                        {
                            GameObject arrow = Instantiate(Arrow.GetComponent<ProjectileHolder>().Get_GameObject(), new Vector3(temp.x - 1, temp.y, temp.z), Arrow.transform.rotation) as GameObject;
                            arrow.SetActive(true);
                            attackTimer = 0.0f;
                        }
                    }
                    //else
                    //{
                    //    // Shift to run away state to increase distance between heroes & archer?
                    //}
                }
                break;
            case States.Death:
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
                    Exit();
                break;
            default:
                break;
        }
    }
}