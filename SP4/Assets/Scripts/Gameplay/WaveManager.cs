using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour 
{
    public GameObject Orc, G_Dwarf_Miner, G_Dwarf_Warrior, G_Dwarf_Archer, B_Dwarf_Miner, B_Dwarf_Warrior, B_Dwarf_Archer, R_Dwarf_Miner, R_Dwarf_Warrior, R_Dwarf_Archer, U_Dwarf_Miner, U_Dwarf_Warrior, U_Dwarf_Archer;

    public static List<GameObject> ListOfMobs;

    private static int WaveNumber, MobNumber, GoldEarned, KillCount;
    private bool WaveOver;
    //public Text WaveProgress;
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
        //WaveProgress.text = "Wave: " + WaveNumber + "\nMonsters Remaining: " + ListOfMobs.Count;

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
        if (WaveNumber < 10)
            MobNumber = Random.Range((5 + WaveNumber), (3 + WaveNumber + 2 * WaveNumber));
        else
            MobNumber = Random.Range(25, 35);
    }

    public void SpawnMobs(int mobID)
    {
        Vector3 tempPos;
        switch(mobID)
        {
            case 0: // Orc
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject newG_Dwarf_Miner = Instantiate(G_Dwarf_Miner, tempPos, G_Dwarf_Miner.transform.rotation) as GameObject;
                newG_Dwarf_Miner.SetActive(true);
                if (newG_Dwarf_Miner == null)
                {
                    Debug.Log("newG_Dwarf_Miner is Null");
                    return;
                }
                ListOfMobs.Add(newG_Dwarf_Miner);
                break;
            case 2: // Green Dwarf Warrior
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
                tempPos = new Vector3((float)(Random.Range(Screen.width / 80, Screen.width / 10)), gameObject.transform.position.y, gameObject.transform.position.z);
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
            int temp = Random.Range(0, 2);
            for (int i = 0; i < MobNumber; i++)
            {
               SpawnMobs(temp);
            }
        }
        else if (WaveNumber > 5 && WaveNumber <= 7)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(0, 3));
            }
        }
        else if (WaveNumber > 7 && WaveNumber <= 9)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(0, 4));
            }
        }
        else if (WaveNumber > 9 && WaveNumber <= 13)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(1, 5));
            }
        }
        else if (WaveNumber > 13 && WaveNumber <= 15)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(2, 6));
            }
        }
        else if (WaveNumber > 15 && WaveNumber <= 16)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(3, 6));
            }
        }
        else if (WaveNumber > 16 && WaveNumber <= 18)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(4, 7));
            }
        }
        else if (WaveNumber > 18 && WaveNumber <= 20)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(5, 8));
            }
        }
        else if (WaveNumber > 20 && WaveNumber <= 22)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(5, 9));
            }
        }
        else if (WaveNumber > 22 && WaveNumber <= 24)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(7, 10));
            }
        }
        else if (WaveNumber > 24 && WaveNumber <= 26)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(8, 11));
            }
        }
        else if (WaveNumber > 26 && WaveNumber <= 28)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(9, 12));
            }
        }
        else if (WaveNumber > 29)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(9, 13));
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

    public static void AddGoldEarned(int goldAdded)
    {
        GoldEarned += goldAdded;
    }

    public static int GetGoldEarned()
    {
        return GoldEarned;
    }

    public static void AddKillCount()
    {
        KillCount++;
    }

    public static int GetKillCount()
    {
        return KillCount;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}