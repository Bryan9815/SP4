using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Mob : MonoBehaviour
{
    protected float Hp, Attack, Defense;
    protected float attackTimer, attackTimer_Max;
    protected Vector3 position;

    public GameObject Hero1, Hero2, Hero3;
    protected static List<GameObject> HeroList;

    // Use this for initialization
    protected virtual void Start()
    {
        Hp = 1;
        Defense = 1;

        HeroList.Add(Hero1);
        HeroList.Add(Hero2);
        HeroList.Add(Hero3);
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual Mob Get_Class()
    {
        return this;
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

    }

    public virtual float Get_AttackTimer()
    {
        return attackTimer;
    }

    public virtual float Get_Max_AttackTimer()
    {
        return attackTimer_Max;
    }

    public virtual Mob Get_ClassType()
    {
        return this;
    }

    public virtual Mob Get_Instance()
    {
        return new Mob();
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
    }
}
