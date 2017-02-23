using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class R_DwarfArcher : Mob
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
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x) + (gameObject.transform.position.y + Hero1.transform.position.y) * (gameObject.transform.position.y + Hero1.transform.position.y));
        if (distFromHero <= 7.5)
        {
            state = States.Walk;
            animator.SetTrigger("Target Detected");
        }
        else if (distFromHero <= 5)
        {
            state = States.Attack;
            animator.SetBool("Targets In Range", true);
        }
        else
        {
            state = States.Idle;
            animator.SetTrigger("No Targets");
        }
        switch (state)
        {
            case States.Idle:

                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime * 2;
                        gameObject.transform.position = temp;
                        Debug.Log("DistFromHero: " + distFromHero);
                    }
                }
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
                            GameObject arrow = Instantiate(Arrow, temp, Arrow.transform.rotation) as GameObject;
                            attackTimer = 0.0f;
                        }
                    }
                    else
                    {
                        // Shift to run away state to increase distance between heroes & archer?
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
