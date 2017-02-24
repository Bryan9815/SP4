using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AttackCollide : MonoBehaviour {

	public static List<Mob> Mobs_Collided;

	// Use this for initialization
	void Start () {
		Mobs_Collided = new List<Mob> ();

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Mobs_Collided.Count; i++) {
			if (!Mobs_Collided [i]) {
				Mobs_Collided.RemoveAt (i);
				i--;
			}
				
		}
	}

//	void OnTriggerEnter2D(Collider2D other) {
//		Mobs_Collided.Add (other.gameObject.GetComponent<Mob> ());
//	}
//	 
//	void OnTriggerExit(Collider other)
//	{
//		if (Mobs_Collided.Contains(other.gameObject.GetComponent<Mob> ()))
//			Mobs_Collided.Remove(other.gameObject.GetComponent<Mob> ());
//	}
}
