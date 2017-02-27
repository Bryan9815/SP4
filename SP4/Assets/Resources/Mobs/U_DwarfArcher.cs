using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class U_DwarfArcher : Mob
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
        goldValue = Random.Range(121, 218);

        attackTimer = 0.0f;
        attackTimer_Max = 3.01f;

        state = States.Idle;
        animator = GetComponent<Animator>();
    }

    void CalculateStats()
    {
        Hp = (int)(152 * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Defense = (int)(73.91f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        exp = (67.62f * WaveManager.GetWaveNumber() * Random.RandomRange(1, 1.43f));

        if (Hp > 10000)
            Hp = 10000;
        if (Defense > 5000)
            Defense = 5000;
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

        if (distFromHero < 10 && distFromHero > 7.5)
        {
            state = States.Walk;
            if (!TargetsDetected)
            {
                animator.SetTrigger("Target Detected");
                animator.SetBool("No Targets", false);
                TargetsDetected = true;
            }
        }
        else if (distFromHero > 10 && state != States.Attack)
        {
            state = States.Idle;
            animator.SetBool("No Targets", true);
            TargetsDetected = false;
        }
        else if (distFromHero < 7.5)
        {
            state = States.Attack;
            animator.SetBool("Targets In Range", true);
            animator.SetFloat("Cooldown Timer", attackTimer);
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

                foreach (GameObject hero in HeroList)
                {
                    if (!gameObject.GetComponent<BoxCollider2D>().IsTouching(hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                    {
                        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

                        temp.x -= Time.deltaTime * 0.5f;
                        gameObject.transform.position = temp;
                    }
                }
                break;
            default:
                break;
        }
    }

    public void FireProjectile()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        GameObject arrow = Instantiate(Arrow.GetComponent<ProjectileHolder>().Get_GameObject(), new Vector3(position.x - 1, position.y, position.z), Arrow.transform.rotation) as GameObject;
        arrow.SetActive(true);

        attackTimer = 0.0f;
        animator.SetFloat("Cooldown Timer", attackTimer);
        animator.SetTrigger("Cooldown");
    }
}
