using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class B_DwarfArcher : Mob
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
        CalculateStats();
        goldValue = Random.Range(30, 46);

        attackTimer = 0.0f;
        attackTimer_Max = 3.01f;

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    void CalculateStats()
    {
        Hp = (int)(101 * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Defense = (int)(37.15f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
    }

    // Update is called once per frame
    protected override void Update()
    {
        float distFromHero = Mathf.Sqrt((float)(gameObject.transform.position.x + Hero1.transform.position.x) * (gameObject.transform.position.x + Hero1.transform.position.x));
        if (distFromHero <= 7.5 && distFromHero > 5)
        {
            state = States.Walk;
            animator.SetTrigger("Target Detected");
            animator.SetBool("No Targets", false);
        }
        else if (distFromHero > 7.5 && state != States.Attack)
        {
            state = States.Idle;
            animator.SetBool("No Targets", true);
        }
        else if (distFromHero <= 5)
        {
            state = States.Attack;
            animator.SetBool("Targets In Range", true);
        }
        switch (state)
        {
            case States.Idle:
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
                if (animator.GetFloat("Cooldown Timer") < attackTimer_Max)
                    attackTimer += Time.deltaTime;
                animator.SetFloat("Cooldown Timer", attackTimer);

                Vector3 temp2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

                if (attackTimer >= attackTimer_Max)
                {
                    GameObject arrow = Instantiate(Arrow.GetComponent<ProjectileHolder>().Get_GameObject(), new Vector3(temp2.x - 1, temp2.y, temp2.z), Arrow.transform.rotation) as GameObject;
                    arrow.SetActive(true);

                    attackTimer = 0.0f;
                    animator.SetFloat("Cooldown Timer", attackTimer);
                    animator.SetTrigger("Cooldown");
                }

                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        temp2.x -= Time.deltaTime * 0.5f;
                        gameObject.transform.position = temp2;
                    }
                }
                break;
            default:
                break;
        }
    }
}
