using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weeb : Hero 
{
    static Weeb _instance;
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
        id = 2;
        ClassName = "Weeb";                                             //Weeb's Class Name
        Attack = level * 8.31f + 9;                                     //Weeb's Attack Value
        Defense = (level * 3.2f) + (Attack /100) + 5;                     //Weeb's Defense Value
        Resistance = 1;                                                             //Useless Stat 1:What is this going to be for if we already have defense?
        Speed = 1;                                                                  //Useless Stat 2: If our hero is static, why is there a need for this
        Accuracy = 1;                                                       //Not really sure if we need this
        Evasion = 48 + ((Defense / 4) * 0.5f);                          //Weeb's Evasion Rate (Maximum of 100% of course)
	    Sp = 100;                                                       //Weeb's Special Points for ultimate (Sort of)
        //hero_img = ;                                                  //Weeb's Sprite I guess?
        name = "Weeb";                                                  //Name of Weeb
        level = 1;                                                      //Weeb's Level
        exp = 1;                                                        //Weeb's Experience points
        max_exp = (level * 100);                                        //Weeb's Experience points needed to level up
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
        GetAttack();
        anim.SetTrigger("BlockPressed");
    }

    protected override void TwoChain()
    {

    }

    protected override void ThreeChain()
    {

    }

    // Normal attack
    protected override void NormalAttack()
    {

    }

    // when attacked
    public override void getHit(int damagetaken)
    {
        //calculate how damage is taken here

    }

    // Special ability
    protected override void SpecialAbility()
    {

    }

    public override void LevelUp()
    {

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
            _instance = new Weeb();
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
