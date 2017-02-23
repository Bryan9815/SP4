using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour 
{
    public GameObject Orc, G_Dwarf_Miner, G_Dwarf_Warrior, G_Dwarf_Archer, B_Dwarf_Miner, B_Dwarf_Warrior, B_Dwarf_Archer, R_Dwarf_Miner, R_Dwarf_Warrior, R_Dwarf_Archer, U_Dwarf_Miner, U_Dwarf_Warrior, U_Dwarf_Archer;

    public static List<GameObject> ListOfMobs;

    private static int WaveNumber, MobNumber;
    private bool WaveOver;
	// Use this for initialization
    void Start()
    {
        WaveNumber = 1;
        WaveOver = false;

        ListOfMobs = new List<GameObject>();
        RandomizeMobNumber();
        GenerateMobs();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!WaveOver)
        {
            if (ListOfMobs.Count <= 0)
                WaveOver = true;
        }
        else
            WaveTransition();
	}

    void RandomizeMobNumber()
    {
        MobNumber = Random.Range((5 + WaveNumber), (3 + WaveNumber + 2 * WaveNumber));
    }

    void SpawnMobs(int mobID)
    {
        Vector3 tempPos;
        switch(mobID)
        {
            case 0: // Orc
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newOrc = Instantiate(Orc, tempPos, Orc.transform.rotation) as GameObject;
                newOrc.SetActive(true);
                if (newOrc == null)
                {
                    Debug.Log("newOrc is Null");
                    return;
                }
                ListOfMobs.Add(newOrc);
                break;
            case 1: // Green Dwarf Miner
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newG_Dwarf_Miner = Instantiate(G_Dwarf_Miner, tempPos, G_Dwarf_Miner.transform.rotation) as GameObject;
                newG_Dwarf_Miner.SetActive(true);
                if (newG_Dwarf_Miner == null)
                {
                    Debug.Log("newG_Dwarf_Miner is Null");
                    return;
                }
                Debug.Log("G_DwarMiner: " + newG_Dwarf_Miner);
                ListOfMobs.Add(newG_Dwarf_Miner);
                break;
            case 2: // Green Dwarf Warrior
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newG_Dwarf_Warrior = Instantiate(G_Dwarf_Warrior, tempPos, G_Dwarf_Warrior.transform.rotation) as GameObject;
                newG_Dwarf_Warrior.SetActive(true);
                if (newG_Dwarf_Warrior == null)
                {
                    Debug.Log("newG_Dwarf_Warrior is Null");
                    return;
                }
                ListOfMobs.Add(newG_Dwarf_Warrior);
                break;
            case 3: // Green Dwarf Archer
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newG_Dwarf_Archer = Instantiate(G_Dwarf_Archer, tempPos, G_Dwarf_Archer.transform.rotation) as GameObject;
                newG_Dwarf_Archer.SetActive(true);
                if (newG_Dwarf_Archer == null)
                {
                    Debug.Log("newG_Dwarf_Archer is Null");
                    return;
                }
                ListOfMobs.Add(newG_Dwarf_Archer);
                break;
            case 4: // Blue Dwarf Miner
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newB_Dwarf_Miner = Instantiate(B_Dwarf_Miner, tempPos, B_Dwarf_Miner.transform.rotation) as GameObject;
                newB_Dwarf_Miner.SetActive(true);
                if (newB_Dwarf_Miner == null)
                {
                    Debug.Log("newB_Dwarf_Miner is Null");
                    return;
                }
                ListOfMobs.Add(newB_Dwarf_Miner);
                break;
            case 5: // Blue Dwarf Warrior
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newB_Dwarf_Warrior = Instantiate(B_Dwarf_Warrior, tempPos, B_Dwarf_Warrior.transform.rotation) as GameObject;
                newB_Dwarf_Warrior.SetActive(true);
                if (newB_Dwarf_Warrior == null)
                {
                    Debug.Log("newB_Dwarf_Warrior is Null");
                    return;
                }
                ListOfMobs.Add(newB_Dwarf_Warrior);
                break;
            case 6: // Blue Dwarf Archer
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newB_Dwarf_Archer = Instantiate(B_Dwarf_Archer, tempPos, B_Dwarf_Archer.transform.rotation) as GameObject;
                newB_Dwarf_Archer.SetActive(true);
                if (newB_Dwarf_Archer == null)
                {
                    Debug.Log("newB_Dwarf_Archer is Null");
                    return;
                }
                ListOfMobs.Add(newB_Dwarf_Archer);
                break;
            case 7: // Red Dwarf Miner
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newR_Dwarf_Miner = Instantiate(R_Dwarf_Miner, tempPos, R_Dwarf_Miner.transform.rotation) as GameObject;
                newR_Dwarf_Miner.SetActive(true);
                if (newR_Dwarf_Miner == null)
                {
                    Debug.Log("newR_Dwarf_Miner is Null");
                    return;
                }
                ListOfMobs.Add(newR_Dwarf_Miner);
                break;
            case 8: // Red Dwarf Warrior
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newR_Dwarf_Warrior = Instantiate(R_Dwarf_Warrior, tempPos, R_Dwarf_Warrior.transform.rotation) as GameObject;
                newR_Dwarf_Warrior.SetActive(true);
                if (newR_Dwarf_Warrior == null)
                {
                    Debug.Log("newR_Dwarf_Warrior is Null");
                    return;
                }
                ListOfMobs.Add(newR_Dwarf_Warrior);
                break;
            case 9: // Red Dwarf Archer
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newR_Dwarf_Archer = Instantiate(R_Dwarf_Archer, tempPos, R_Dwarf_Archer.transform.rotation) as GameObject;
                newR_Dwarf_Archer.SetActive(true);
                if (newR_Dwarf_Archer == null)
                {
                    Debug.Log("newR_Dwarf_Archer is Null");
                    return;
                }
                ListOfMobs.Add(newR_Dwarf_Archer);
                break;
            case 10: // Black Dwarf Miner
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newU_Dwarf_Miner = Instantiate(U_Dwarf_Miner, tempPos, U_Dwarf_Miner.transform.rotation) as GameObject;
                newU_Dwarf_Miner.SetActive(true);
                if (newU_Dwarf_Miner == null)
                {
                    Debug.Log("newU_Dwarf_Miner is Null");
                    return;
                }
                ListOfMobs.Add(newU_Dwarf_Miner);
                break;
            case 11: // Black Dwarf Warrior
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newU_Dwarf_Warrior = Instantiate(U_Dwarf_Warrior, tempPos, U_Dwarf_Warrior.transform.rotation) as GameObject;
                newU_Dwarf_Warrior.SetActive(true);
                if (newU_Dwarf_Warrior == null)
                {
                    Debug.Log("newU_Dwarf_Warrior is Null");
                    return;
                }
                ListOfMobs.Add(newU_Dwarf_Warrior);
                break;
            case 12: // Black Dwarf Archer
                tempPos = new Vector3((float)(Random.Range(Screen.width / 20, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newU_Dwarf_Archer = Instantiate(U_Dwarf_Archer, tempPos, U_Dwarf_Archer.transform.rotation) as GameObject;
                newU_Dwarf_Archer.SetActive(true);
                if (newU_Dwarf_Archer == null)
                {
                    Debug.Log("newU_Dwarf_Archer is Null");
                    return;
                }
                ListOfMobs.Add(newU_Dwarf_Archer);
                break;
            default:
                break;
        }
    }

    void GenerateMobs()
    {
        if (WaveNumber <= 3)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(0);
            }
        }
        else if (WaveNumber > 3 && WaveNumber <= 5)
        {
            int temp = Random.Range(0, 1);
            for (int i = 0; i < MobNumber; i++)
            {
               SpawnMobs(temp);
            }
        }
        else if (WaveNumber > 5 && WaveNumber <= 7)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(0, 2));
            }
        }
        else if (WaveNumber > 8 && WaveNumber <= 9)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(0, 3));
            }
        }
        else if (WaveNumber > 10 && WaveNumber <= 13)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(1, 3));
            }
        }
        else if (WaveNumber > 14 && WaveNumber <= 15)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(2, 4));
            }
        }
        else if (WaveNumber > 15 && WaveNumber <= 16)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(3, 5));
            }
        }
        else if (WaveNumber > 17 && WaveNumber <= 18)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(4, 6));
            }
        }
        else if (WaveNumber > 19 && WaveNumber <= 20)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(5, 7));
            }
        }
        else if (WaveNumber > 21 && WaveNumber <= 22)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(5, 8));
            }
        }
        else if (WaveNumber > 23 && WaveNumber <= 24)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(7, 9));
            }
        }
        else if (WaveNumber > 25 && WaveNumber <= 26)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(8, 10));
            }
        }
        else if (WaveNumber > 27 && WaveNumber <= 28)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(9, 11));
            }
        }
        else if (WaveNumber > 29)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(9, 12));
            }
        }
    }

    void WaveTransition()
    {
        WaveNumber++;
        RandomizeMobNumber();
        GenerateMobs();
        WaveOver = false;
    }

    public static int GetWaveNumber()
    {
        return WaveNumber;
    }
}