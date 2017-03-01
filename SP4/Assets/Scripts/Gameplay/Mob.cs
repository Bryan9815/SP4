using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Mob : MonoBehaviour
{
    protected int Hp, Attack, Defense, goldValue;
    protected float attackTimer, attackTimer_Max, exp, distFromHero;
    protected Vector3 position;
    protected bool TargetsDetected = false;
    protected bool isHit = false;

    protected static GameObject Hero1, Hero2, Hero3, Arrow;
    protected static List<GameObject> HeroList;

    // Use this for initialization
    protected virtual void Start()
    {
        Hp = 1;
        Defense = 1;
        attackTimer = 0.0f;
        attackTimer_Max = 3.5f;

        Arrow = GameObject.Find("Arrow");

        HeroList = new List<GameObject>();

        Hero1 = GameObject.Find("Hero1");
        Hero2 = GameObject.Find("Hero2");
        Hero3 = GameObject.Find("Hero3");

        HeroList.Add(Hero1);
        HeroList.Add(Hero2);
        HeroList.Add(Hero3);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead()&& Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead()&& Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
            WaveManager.GameOver();
    }

    public virtual void SetPosition(Vector3 pos)
    {
        position = pos;
    }

    public virtual Vector3 GetPosition()
    {
        return position;
    }

    // when attacked
    public virtual void getHit(int damage)
    {
        //calculate how damage is taken here
        Hp -= damage;

        Vector3 tempPos = gameObject.transform.position;
        tempPos.y += gameObject.GetComponent<Transform>().localScale.y / 2;
        DamageTextManager.GenerateSprite(tempPos, damage);
        Debug.Log("Ai ya Mob got hit...");
    }

    public virtual void getHit(int damage, bool careAboutTrigger)
    {
        //calculate how damage is taken here
        if (careAboutTrigger)
        {
            if (!isHit)
            {
                Hp -= damage;

                Vector3 tempPos = gameObject.transform.position;
                tempPos.y += gameObject.GetComponent<Transform>().localScale.y / 2;
                DamageTextManager.GenerateSprite(tempPos, damage);
                Debug.Log("Ai ya Mob got hit...");
            }
        }
        else
            getHit(damage);
    }

    public virtual int GetAttack()
    {
        return Attack;
    }

    public void isHitTrigger()
    {
        isHit = true;
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
        WaveManager.ListOfMobs.Remove(gameObject);
        WaveManager.AddKillCount();
        WaveManager.AddGoldEarned(goldValue);
        Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().IncreaseExp(exp);
        Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().IncreaseExp(exp);
        Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().IncreaseExp(exp);
    }

	protected virtual void OnTriggerEnter2D(Collider2D other) {
		AttackCollide.Mobs_Collided.Add (this);

	}
}
