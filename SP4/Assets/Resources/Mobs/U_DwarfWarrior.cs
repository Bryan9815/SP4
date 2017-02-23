using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class U_DwarfWarrior : Mob
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
    protected override void Start()
    {
        Hp = 10;
        Defense = 10;

        attackTimer = 0.0f;
        attackTimer_Max = 2.0f;

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x));

        // State Transition
        if (distFromHero <= 7.5 && state != States.Attack)
        {
            state = States.Walk;
        }
        else if (distFromHero > 7.5 && state != States.Attack)
        {
            state = States.Idle;
        }
        else if (distFromHero > 4 && state == States.Attack)
        {
            state = States.Walk;
            animator.SetBool("Targets In Range", false);
        }
        if (Hp <= 0)
        {
            state = States.Death;
            animator.SetTrigger("No HP");
        }
        switch (state)
        {
            case States.Idle:
                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime * 2;
                        gameObject.transform.position = temp;
                    }
                }
                break;
            case States.Walk:
                animator.SetTrigger("Target Detected");
                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime;
                        gameObject.transform.position = temp;
                    }
                    else
                    {
                        state = States.Attack;
                        animator.SetBool("Targets In Range", true);
                    }
                }
                break;
            case States.Attack:
                attackTimer += Time.deltaTime;
                foreach (GameObject hero in HeroList)
                {
                    if (attackTimer >= attackTimer_Max)
                    {
                        hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                        attackTimer = 0.0f;
                    }
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
