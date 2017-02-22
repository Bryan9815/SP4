using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class G_DwarfMiner : Mob
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

        //gameObject.transform.position.Set((float)(Random.Range(Screen.width, Screen.width * 3)), gameObject.transform.position.y, gameObject.transform.position.z);
        state = States.Idle;
        animator = GetComponent<Animator>();

        HeroList = new List<GameObject>();

        HeroList.Add(Hero1);
        HeroList.Add(Hero2);
        HeroList.Add(Hero3);
    }

    // Update is called once per frame
    void Update()
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x) + (gameObject.transform.position.y + Hero1.transform.position.y) * (gameObject.transform.position.y + Hero1.transform.position.y));
        foreach (GameObject hero in HeroList)
        {
            if (distFromHero <= 7.5)
            {
                state = States.Walk;
            }
            else
            {
                state = States.Idle;
            }
        }
        //Debug.Log("dist between hero1 & mob: " + distFromHero);
        switch (state)
        {
            case States.Idle:

                foreach (GameObject hero in HeroList)
                {
                    animator.SetTrigger("Idle");
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime * 2;
                        gameObject.transform.position = temp;
                    }
                }
                break;
            case States.Walk:
                foreach (GameObject hero in HeroList)
                {
                    animator.SetTrigger("Run");
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        temp.x -= Time.deltaTime;
                        gameObject.transform.position = temp;
                    }
                    else
                    {
                        Destroy(gameObject);
                        WaveManager.ListOfMobs.Remove(gameObject);
                        Debug.Log("Destroyed");
                    }
                }
                break;
            default:
                break;
        }
    }
}
