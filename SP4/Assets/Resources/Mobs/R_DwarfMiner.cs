using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class R_DwarfMiner : Mob
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

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x) + (gameObject.transform.position.y + Hero1.transform.position.y) * (gameObject.transform.position.y + Hero1.transform.position.y));
        if (distFromHero <= 7.5)
        {
            state = States.Walk;
            animator.SetTrigger("Target Detected");
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
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<BoxCollider2D>()))
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
                    else
                    {
                        state = States.Attack;
                        animator.SetBool("Targets In Range", true);
                    }
                }
                break;
            case States.Attack:

                break;
            case States.Death:
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
                {
                    Destroy(gameObject);
                    WaveManager.ListOfMobs.Remove(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
