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
    protected override void Start()
    {
        CalculateStats();
        goldValue = Random.Range(49, 70);

        attackTimer = 0.0f;
        attackTimer_Max = 3.01f;

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    void CalculateStats()
    {
        Hp = (int)(146 * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Attack = (int)(60.9f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Defense = (int)(56.91f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        exp = (47.56f * WaveManager.GetWaveNumber() * Random.RandomRange(1, 1.43f));
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

        // State Transition
        if (distFromHero < 7.5 && state != States.Attack && !animator.GetBool("Targets In Range"))
        {
            state = States.Walk;
            if (!TargetsDetected)
            {
                animator.SetTrigger("Target Detected");
                TargetsDetected = true;
            }
        }
        else if (distFromHero > 7.5 && state != States.Attack)
        {
            state = States.Idle;
            TargetsDetected = false;
        }
        else if (distFromHero > 5 && state == States.Attack)
        {
            state = States.Walk;
            animator.SetBool("Targets In Range", false);
        }
        if (Hp <= 0)
        {
            state = States.Death;
            animator.SetTrigger("No HP");
        }

        // States
        switch (state)
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
                        animator.SetBool("No Targets", false);
                    }
                }
                break;
            case States.Attack:
                if (attackTimer < attackTimer_Max)
                    attackTimer += Time.deltaTime;
                animator.SetFloat("Cooldown Timer", attackTimer);

                break;
            default:
                break;
        }
    }

    public void AttackHero()
    {
        float accuracy = Random.Range(1, 101);
        if (!Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
        {
            if (accuracy > Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
        }
        else if (!Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
        {
            if (accuracy > Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
        }
        else if (!Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
        {
            if (accuracy > Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
        }
        attackTimer = 0.0f;
        animator.SetFloat("Cooldown Timer", 0);
    }
}