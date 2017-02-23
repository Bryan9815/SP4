using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cloud : Hero
{
    static Cloud _instance;
    Animator anim;
    enum States // for animation
    {
        Idle,
        Attack,

        Death,
    }
    // Use this for initialization
    protected override void Start()
    {
        id = 1;
        ClassName = "Cloud";                                            //Cloud's Class Name
        Hp = level * 10 + 105;                                          //Cloud's Health Points
        Attack = level * 17.25f + 9;                                    //Cloud's Attack Value
        Defense = (level * 14.31f) + (Attack / 100) + 5;                //Cloud's Defense Value
        Resistance = 1;                                                             //Useless Stat 1:What is this going to be for if we already have defense?
        Speed = 1;                                                                  //Useless Stat 2: If our hero is static, why is there a need for this
        Accuracy = 1;                                                       //Not really sure if we need this
        Evasion = 48 + (((Attack - Defense) / 12));                     //Cloud's Evasion Rate (Maximum of 100% of course)
        Sp = 100;                                                       //Cloud's Special Points for ultimate (Sort of)
        //hero_img = ;                                                  //Cloud's Sprite I guess?
        name = "Cloud";                                                 //Name of Cloud
        level = 1;                                                      //Cloud's Level
        exp = 0;                                                        //Cloud's Experience points
        max_exp = (level * 100);                                        //Cloud's Experience points needed to level up
        //state;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }


    protected override Hero Get_Class()
    {
        return this;
    }

    public override void BlockAttack(int i)
    {
        switch (i)
        {
            case 1:
                OneChain();
                break;
            case 2:
                TwoChain();
                break;
            case 3:
                ThreeChain();
                break;
        }
    }

    // Chain attacks
    protected override void OneChain()
    {
       if(attackCollider.GetComponent<Collider2D>().IsTouching(GameObject.Find("Orc").GetComponent<Collider2D>()))
       {
           anim.SetInteger("Number of Blocks", 1);
           anim.SetTrigger("BlockPressed");
           //EnemyHp -= GetAttack() * 1.0f;
       }
        Debug.Log("LOLXDXD");
    }

    protected override void TwoChain()
    {
        //Damage = GetAttack() * 2.0f;
        anim.SetInteger("Number of Blocks", 2);
        anim.SetTrigger("BlockPressed");
    }

    protected override void ThreeChain()
    {
        //Damage = GetAttack() * 3.0f;
        anim.SetInteger("Number of Blocks", 3);
        anim.SetTrigger("BlockPressed");
    }

    // Normal attack
    protected override void NormalAttack()
    {

    }

    // when attacked
    public override void getHit(int damagetaken)
    {
        //calculate how damage is taken here
        if(damagetaken - GetDefense() > 0)
        {
            Hp -= (damagetaken - GetDefense());
        }
        else { 

}
    }

    // Special ability
    protected override void SpecialAbility()
    {
        //Damage = GetAttack() * 3;
        //Hp = (Attack * 3) * 0.3f;
        anim.SetTrigger("Skill Activated");
    }

    public override void LevelUp()
    {
        exp = 0;
        level += 1;
        max_exp = (level * 100);
    }

    public override void SetAttack(int newAtk)
    {
        Attack = newAtk;
    }

    public override float GetAttack()
    {
        return Attack;
    }

    public override void SetDefense(int newDef)
    {
        Defense = newDef;
    }

    public override float GetDefense()
    {
        return Defense;
    }

    public override void SetImage(Sprite newHero_img)
    {
        gameObject.GetComponent<Image>().sprite = newHero_img;
        //hero_img = newHero_img;
    }

    public override Sprite GetImage()
    {
        return gameObject.GetComponent<Image>().sprite;
    }

    public override int Get_Id()
    {
        return id;
    }

    public override float Get_AttackTimer()
    {
        return attackTimer;
    }

    public override float Get_Max_AttackTimer()
    {
        return attackTimer_Max;
    }

    public override string Get_ClassName()
    {
        return ClassName;
    }

    public override Hero Get_ClassType()
    {
        return this;
    }

    public override Hero Get_Instance()
    {
        if (_instance == null)
        {
            _instance = new Cloud();
            _instance.Start();
            return _instance;
        }

        else
            return _instance;

    }

    public override void Exit()
    {
        Destroy(gameObject);
    }
}
