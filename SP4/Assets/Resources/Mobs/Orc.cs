using UnityEngine;
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
    float distFromHero;

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
        Hp = (int)(7 * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Attack = (int)(11.4f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        Defense = (int)(7.699f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        exp = (100.56f * WaveManager.GetWaveNumber() * Random.RandomRange(1, 1.43f));
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
                    else
                    {
                        attackTimer += Time.deltaTime;
                        if (attackTimer > attackTimer_Max)
                        {
                            float accuracy = Random.Range(1, 101);
                            if (!Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead() && gameObject.GetComponent<BoxCollider2D>().IsTouching(Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                            {
                                if (accuracy > Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                                    Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                            }
                            else if (!Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead() && gameObject.GetComponent<BoxCollider2D>().IsTouching(Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                            {
                                if (accuracy > Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                                    Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                            }
                            else if (!Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead() && gameObject.GetComponent<BoxCollider2D>().IsTouching(Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<BoxCollider2D>()))
                            {
                                if (accuracy > Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                                    Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                            }
                            attackTimer = 0;
                        }
                    }
                }
                break;
            default:
                break;
        }
	}
}
