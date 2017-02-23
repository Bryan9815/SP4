using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Mob : MonoBehaviour
{
    protected int Hp, Attack, Defense;
    protected float attackTimer, attackTimer_Max;
    protected Vector3 position;

    protected static GameObject Hero1, Hero2, Hero3, Arrow, attackCollider;
    protected static List<GameObject> HeroList;
    // Use this for initialization
    protected virtual void Start()
    {
        Hp = 1;
        Defense = 1;

        Arrow = GameObject.Find("Arrow");
        attackCollider = GameObject.Find("AttackCollider");
        Debug.Log("Attack Collider: " + attackCollider);

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
    }
}
