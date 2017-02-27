using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour {

	protected float Attack;
	protected Sprite WeaponImage;
	protected int Level;			//Capped at 5
	protected int Max_level;
	protected string Name;

	protected virtual void Awake () {
		Level = 1;
		Max_level = 5;
		Name = "";
		//WeaponImage = Resources.Load<Sprite>("Equipment/Image/ImageName");
		CalculateAttack ();
	}

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	protected virtual void CalculateAttack()
	{
		Attack = 10f * Level * 0.5f;
	}

	public virtual float Get_Attack()
	{
		return Attack;
	}

	public virtual Sprite Get_Image()
	{
		return WeaponImage;
	}

	public virtual int Get_Level()
	{
		return Level;
	}

	public virtual bool LevelUp()
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

	public virtual void LoadData(string HeroName)
	{
		
	}
}
