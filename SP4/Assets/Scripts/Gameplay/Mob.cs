using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Mob : MonoBehaviour
{
    protected int Hp, Attack, Defense, goldValue;
    protected float attackTimer, attackTimer_Max;
    protected Vector3 position;

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
    }

    public virtual int GetAttack()
    {
        return Attack;
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
        WaveManager.ListOfMobs.Remove(gameObject);
        WaveManager.AddKillCount();
        WaveManager.AddGoldEarned(goldValue);
        Debug.Log("Gold Earned: " + WaveManager.GetGoldEarned());
        Debug.Log("Kill Count: " + WaveManager.GetKillCount());
    }

	protected virtual void OnTriggerEnter2D(Collider2D other) {
		AttackCollide.Mobs_Collided.Add (this);

	}
}
