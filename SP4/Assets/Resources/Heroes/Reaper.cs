using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reaper : Hero
{
    static Reaper _instance;
    private GameObject Scythe;

    // Use this for initialization
    protected override void Start()
    {
        currHp = Hp;
        id = 4;
        ClassName = "Reaper";
        name = "Reaper";
        Sp = 0;
        level = PlayerPrefs.GetInt("Reaper Level", 1);                   //Reaper's Level
        exp = PlayerPrefs.GetFloat("Reaper EXP", 0);                     //Reaper's Experience points

        if (level == 1)
            CalculateStats();
        else
        {
            Hp = PlayerPrefs.GetFloat("Reaper HP");
            Attack = PlayerPrefs.GetFloat("Reaper Attack");
            Defense = PlayerPrefs.GetFloat("Reaper Defense");
            Evasion = PlayerPrefs.GetFloat("Reaper Evasion");
            max_exp = PlayerPrefs.GetFloat("Reaper Max_EXP");
        }
        currHp = Hp;
        isDead = false;
        animator = GetComponent<Animator>();
        InvincibilityTimer = 0;
        InvincibilityDuration = 1f;

        Scythe = GameObject.Find("Scythe");
    }

    void CalculateStats()
    {										//Max
        Hp = 100 * level * 1.1f;			//5500
        Attack = 13 * level * 1;			//900
        Defense = 15 * level * 1.2f;		//550
        Evasion = 0.7f * level * 0.9f;		//31.5
        max_exp = 500 * level * 2;			//50k
    }

    void FireProjectile()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        GameObject scythe = Instantiate(Scythe.GetComponent<ProjectileHolder>().Get_GameObject(), new Vector3(position.x + 1, position.y, position.z), Scythe.transform.rotation) as GameObject;
        scythe.GetComponent<Scythe>().CalculateStats(Attack);
        scythe.SetActive(true);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isDead)
            return;
        if (Sp >= 100)
        {
            Sp -= 100;
            SpecialAbility();
        }

        if (InvincibilityTimer > 0)
        {
            InvincibilityTimer -= Time.deltaTime;
            if (GetComponent<SpriteRenderer>().enabled)
                GetComponent<SpriteRenderer>().enabled = false;
            else
                GetComponent<SpriteRenderer>().enabled = true;
            if (InvincibilityTimer < 0)
            {
                InvincibilityTimer = 0;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            if (!GetComponent<SpriteRenderer>().enabled)
                GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    protected override Hero Get_Class()
    {
        return this;
    }

    public override void BlockAttack(int i)
    {
        if (isDead)
            return;
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
        PlayerPrefs.SetFloat("Reaper EXP", exp);
    }

    // Chain attacks
    protected override void OneChain()
    {
        //state = States.Chain1;
        animator.SetInteger("Number of Blocks", 1);
        animator.SetTrigger("Blocks Pressed");

        foreach (Mob temp in AttackCollide.Mobs_Collided)
        {
            temp.getHit((int)(Attack));
        }

        Sp += 20;
    }

    protected override void TwoChain()
    {
        //state = States.Chain2;
        animator.SetInteger("Number of Blocks", 2);
        animator.SetTrigger("Blocks Pressed");

        foreach (Mob temp in AttackCollide.Mobs_Collided)
        {
            temp.getHit((int)(Attack * 1.5f));
        }
        Sp += 40;
    }

    protected override void ThreeChain()
    {
        //state = States.Chain3;
        animator.SetInteger("Number of Blocks", 3);
        animator.SetTrigger("Blocks Pressed");

        foreach (Mob temp in AttackCollide.Mobs_Collided)
        {
            temp.getHit((int)(Attack * 2f));
        }
        Sp += 60;
    }

    // when attacked
    public override void getHit(int damagetaken)
    {
        if (isDead)
            return;
        if (InvincibilityTimer > 0)
            return;
        //calculate how damage is taken here
        InvincibilityTimer += InvincibilityDuration;
        animator.SetTrigger("isHit");
        currHp -= damagetaken;

        Vector3 tempPos = gameObject.transform.position;
        tempPos.y += gameObject.GetComponent<Transform>().localScale.y / 2;
        DamageTextManager.GeneratePlayerTakeDmg(tempPos, damagetaken);

        Debug.Log("Ai yaa Reaper got hit....");

        if (currHp <= 0)
        {
            isDead = true;
            animator.SetBool("No HP", true);
        }
    }

    // Special ability
    protected override void SpecialAbility()
    {
        animator.SetTrigger("Skill Activated");
    }

    public override void LevelUp()
    {
        level += 1;
        exp = 0;
        CalculateStats();
        currHp = Hp;
        PlayerPrefs.SetInt("Reaper Level", level);
        PlayerPrefs.SetFloat("Reaper HP", Hp);
        PlayerPrefs.SetFloat("Reaper Attack", Attack);
        PlayerPrefs.SetFloat("Reaper Defense", Defense);
        PlayerPrefs.SetFloat("Reaper Evasion", Evasion);
        PlayerPrefs.SetFloat("Reaper Max_EXP", max_exp);
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

    public override Sprite GetSprite()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
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
            _instance = new Reaper();
            _instance.Start();
            return _instance;
        }

        else
            return _instance;

    }
}
