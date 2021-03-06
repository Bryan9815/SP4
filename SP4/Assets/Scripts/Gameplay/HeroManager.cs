﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class HeroManager : MonoBehaviour {

	public GameObject Active_Hero1;
	public GameObject Active_Hero2;
	public GameObject Active_Hero3;

	public static List<GameObject> List_ofHeroes;

	// Use this for initialization
	void Start () {
		int id_1 = 1;//GlobalVariable.GetPlayerHeroID (0);
		GameObject temp = (GameObject)Resources.Load ("Heroes/" + id_1.ToString(), typeof(GameObject));
		//Active_Hero1.GetComponent<HeroHolder> ().Set_GameObject(Instantiate(temp));
//		Active_Hero2.GetComponent<HeroHolder> ().Set_GameObject();
//		Active_Hero3.GetComponent<HeroHolder> ().Set_GameObject();

		//Active_Hero1.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().unlocked = true;

		List_ofHeroes = new List<GameObject> ();
		List_ofHeroes.Add (Active_Hero1);
		List_ofHeroes.Add (Active_Hero2);
		List_ofHeroes.Add (Active_Hero3);
		List_ofHeroes [0].GetComponent<HeroHolder> ().HeroSlot = 1;
		List_ofHeroes [1].GetComponent<HeroHolder> ().HeroSlot = 2;
		List_ofHeroes [2].GetComponent<HeroHolder> ().HeroSlot = 3;

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Set_ActiveHero(int slot, int id)
	{
		switch (slot)
		{
		case 0:
			{
				//Destroy ();
				Active_Hero1.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Exit ();
				GameObject temp = (GameObject)Resources.Load ("Heroes/" + id.ToString(), typeof(GameObject));
				Active_Hero1.GetComponent<HeroHolder> ().Set_GameObject (Instantiate (temp));
			}

			break;
		case 1:
			{
				//Destroy (Active_Hero2.GetComponent<HeroHolder> ().Get_GameObject ());
				Active_Hero2.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Exit ();
				GameObject temp = (GameObject)Resources.Load ("Heroes/" + id.ToString(), typeof(GameObject));
				Active_Hero2.GetComponent<HeroHolder> ().Set_GameObject (Instantiate (temp));
			}
			break;
		case 2:
			{
				//Destroy (Active_Hero3.GetComponent<HeroHolder> ().Get_GameObject ());
				Active_Hero3.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Exit ();
				GameObject temp = (GameObject)Resources.Load ("Heroes/" + id.ToString(), typeof(GameObject));
				Active_Hero3.GetComponent<HeroHolder> ().Set_GameObject (Instantiate (temp));
			}
			break;
		}
	}

	public int Get_ActiveHero(int slot)
	{
		switch (slot) 
		{
		case 0:
			return Active_Hero1.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Get_Id ();
			break;
		case 1:
			Active_Hero2.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Get_Id ();
			break;
		case 2:
			Active_Hero3.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Get_Id ();
			break;
		}
		return -1;
	}



	public void Exit()
	{
		Active_Hero1.GetComponent<HeroHolder> ().Get_GameObject ().GetComponent<Hero> ().Get_Id ();
	}

//	private Dictionary<int,GameObject> Map_ofHeros_ID;
//	private Dictionary<string,GameObject> Map_ofHeros_Name;
//	private List<GameObject> List_ofActiveHeros;
//	public GameObject HeroGameobj;
//	//int heroslot;
//	// Use this for initialization
//
//	void Start () {
//		//UnityEngine.Object[] scripts = Resources.LoadAll ("Scripts/Heroes");
//		Map_ofHeros_ID = new Dictionary<int,GameObject> ();
//		Map_ofHeros_Name = new Dictionary<string,GameObject> ();
////		List_ofActiveHeros = new List<GameObject> ();
////
////		var loadedobj = Resources.LoadAll ("Heroes");
////		List<Hero> listofhero = new List<Hero> ();
////		foreach (var hero in loadedobj)
////		{
////			//Hero temp = hero as Hero;
////			//Map_ofHeros.Add (temp.Get_Id(),temp);
////			listofhero.Add (hero as Hero);
////			Debug.Log ("Send help");
////		}
//		var gameobjprefab = Resources.LoadAll ("Heroes", typeof(GameObject));
//
//		foreach (var temp in gameobjprefab)
//		{
//			//Hero t = Instantiate(temp as GameObject);
////			Debug.Log (t.gameObject);
////			Map_ofHeros_ID.Add(t.Get_Id(),t);
////			Map_ofHeros_Name.Add(t.Get_ClassName(),t);
//		}
//
//		for (int i = 0; i < 3; i++)
//		{
//			List_ofActiveHeros.Add (Instantiate(HeroGameobj));
//		}
//		//Set_Hero (0, "Leon");
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		//List_ofHeroes[2].id
//	}
//
//
//	void Set_Hero(int hero_slot,int id)
//	{
//		if (List_ofActiveHeros [hero_slot].GetComponent<Hero> () != null)
//		{
//			List_ofActiveHeros [hero_slot].GetComponent<Hero> ().Exit ();
//		}
//		Destroy (List_ofActiveHeros [hero_slot]);
//		List_ofActiveHeros.RemoveAt (hero_slot);
//		GameObject temp = new GameObject ();
//		string t = "Scripts/Heroes/";
//		//t += Map_ofHeros [id].Get_ClassName ();
//		Hero hero_temp = Resources.Load ("t") as Hero;
//
//		//temp.AddComponent(hero_temp.Get_ClassName());
//		temp.AddComponent(hero_temp.Get_ClassType().GetType());
//		List_ofActiveHeros.Insert (hero_slot, temp);
//	}
//
//	void Set_Hero(int hero_slot,string name)
//	{
//		if (List_ofActiveHeros [hero_slot].GetComponent<Hero> () != null)
//		{
//			List_ofActiveHeros [hero_slot].GetComponent<Hero> ().Exit ();
//		}
//		Destroy (List_ofActiveHeros [hero_slot]);
//		List_ofActiveHeros.RemoveAt (hero_slot);
//		GameObject temp = new GameObject ();
//		string t = "Heroes/";
//		t += name;
//		Hero hero_temp = Resources.Load ("t") as Hero;
//		//temp.AddComponent(hero_temp.Get_ClassName());
//		temp.AddComponent(hero_temp.Get_Instance().Get_ClassType().GetType());
//		List_ofActiveHeros.Insert (hero_slot, temp);
//	}
}
