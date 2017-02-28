using UnityEngine;
using System.Collections;

public class Scythe : Hero 
{
    float lifetime;
	// Use this for initialization
	void Start () 
    {
        lifetime = 0;
	}

    public void CalculateStats(float atk)
    {
        Attack = atk * 5.0f;
    }
	
	// Update is called once per frame
	void Update () 
    {
        lifetime += Time.deltaTime;
        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        temp.x += Time.deltaTime * 10.0f;
        gameObject.transform.position = temp;
        if (lifetime > 1.25f)
            Destroy(gameObject);
        foreach (GameObject mob in WaveManager.ListOfMobs)
        {
            if(gameObject.transform.position.x >= mob.transform.position.x)
            {
                mob.GetComponent<Mob>().getHit((int)Attack, true);
                mob.GetComponent<Mob>().isHitTrigger();
            }
        }
	}
}
