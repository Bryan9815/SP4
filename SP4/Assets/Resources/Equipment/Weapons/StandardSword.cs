using UnityEngine;
using System.Collections;

public class StandardSword : BaseWeapon {

	protected override void Awake () {
		Level = 1;
		Max_level = 5;
		Name = "TestWeapon1";
        WeaponImage = Resources.Load<Sprite>("Equipment/Items/W_Sword001");
        cost = 50;
        id = 2;
		CalculateAttack ();
	}

	// Use this for initialization
	protected override void Start () {

	}

	// Update is called once per frame
	protected override void Update () {

	}

	protected override void CalculateAttack()
	{
		Attack = 10f * Level * 0.5f;
	}

    public override string Get_Name()
    {
        return Name;
    }

	public override float Get_Attack()
	{
		return Attack;
	}

	public override Sprite Get_Image()
	{
		return WeaponImage;
	}

	public override int Get_Level()
	{
		return Level;
	}

    public override int Get_MaxLevel()
    {
        return Max_level;
    }


	public override bool LevelUp()
	{
		Level += 1;
		if (Level > Max_level)
		{
			Level -= 1;
			return false;
		}

		CalculateAttack ();
		return true;
	}

}
