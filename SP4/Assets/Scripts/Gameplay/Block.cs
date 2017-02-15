using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Block : MonoBehaviour {
    public Button gameobject;
    private static string Name;
    private static int block_slot;
    private static int hero_slot;
    private static bool active;
    public float Block_Travel_Speed;

    enum Chain
    {
        One_Chain,
        Two_Chain_Left,
        Two_Chain_Right,
        Three_Chain_Left,
        Three_Chain_Right
    }

    Chain chain_type;

	// Use this for initialization
	void Start () {
        Name = gameobject.name;
        active = true;
        block_slot = 0;
        hero_slot = 0;
        chain_type = Chain.One_Chain;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void set_BlockSlot(int blockslot)
    {
        block_slot = blockslot;
    }

    public int get_BlockSlot()
    {
        return block_slot;
    }

    public void set_HeroSlot(int newHeroslot)
    {
        hero_slot = newHeroslot;
    }

    public int get_HeroSlot()
    {
        return hero_slot;
    }

    public void set_Active(bool _active)
    {
        active = _active;
    }

    public bool get_Active()
    {
        return active;
    }


    public void Set_Transform_X(float x_value)
    {
        //gameobject.transform.position.x + Time.deltaTime * Block_Travel_Speed
        //Vector3 temp = new Vector3(x_value, 0);
        gameobject.transform.position.Set(
            x_value,
            gameobject.transform.position.y,
            gameobject.transform.position.z);
    }

    public void Activate()
    {
        active = false;
        int chain_no = 0;
        switch (chain_type)
        {
            case Chain.Three_Chain_Left:
                {
                    Block temp = BlockManager.Instance.Listof_Blocks[block_slot + 1].GetComponent<Block>();
                    Block temp2 = BlockManager.Instance.Listof_Blocks[block_slot + 2].GetComponent<Block>();
                    temp.set_Active(false);
                    temp2.set_Active(false);
                    chain_no = 3;
                }                
                break;
            case Chain.Three_Chain_Right:
                {
                    Block temp = BlockManager.Instance.Listof_Blocks[block_slot - 1].GetComponent<Block>();
                    Block temp2 = BlockManager.Instance.Listof_Blocks[block_slot - 2].GetComponent<Block>();
                    temp.set_Active(false);
                    temp2.set_Active(false);
                    chain_no = 3;
                }                
                break;
            case Chain.Two_Chain_Left:
                {
                    Block temp = BlockManager.Instance.Listof_Blocks[block_slot + 1].GetComponent<Block>();                    
                    temp.set_Active(false);
                    chain_no = 2;
                }
                break;
            case Chain.Two_Chain_Right:
                {
                    Block temp = BlockManager.Instance.Listof_Blocks[block_slot - 1].GetComponent<Block>();
                    temp.set_Active(false);
                    chain_no = 2;
                }
                break;
            case Chain.One_Chain:
                {
                    chain_no = 1;
                }
                break;
        }
        // Run respective hero stuffs here
    }
    public void CheckBlockChain()
    {
        if (block_slot >= 2)
        {
            //right
            if (ThreeChainCheck_Right())
                chain_type = Chain.Three_Chain_Right;
            else if (TwoChainCheck_Right())
                chain_type = Chain.Two_Chain_Right;
            //left
            else if (ThreeChainCheck_Left())
                chain_type = Chain.Three_Chain_Left;
            else if (TwoChainCheck_Left())
                chain_type = Chain.Two_Chain_Left;
            //No chain
            else
                chain_type = Chain.One_Chain;
        }
        else if (block_slot == 1)
        {
            //right
            if (ThreeChainCheck_Right())
                chain_type = Chain.Three_Chain_Right;
            else if (TwoChainCheck_Right())
                chain_type = Chain.Two_Chain_Right;
            //left
            else if (TwoChainCheck_Left())
                chain_type = Chain.Two_Chain_Left;
            //No chain
            else
                chain_type = Chain.One_Chain;
        }
        else
        {
            if (ThreeChainCheck_Right())
                chain_type = Chain.Three_Chain_Right;
            else if (TwoChainCheck_Right())
                chain_type = Chain.Two_Chain_Right;
            else
                chain_type = Chain.One_Chain;
        }
    }

    //void OneChainCheck_Left()
    //{
    //    if (BlockManager.Instance.Listof_Blocks[block_slot])
    //}

    //void OneChainCheck_Right()
    //{
    //    if (BlockManager.Instance.Listof_Blocks[block_slot])
    //}

    bool TwoChainCheck_Left()
    {
        Block temp = BlockManager.Instance.Listof_Blocks[block_slot + 1].GetComponent<Block>();
        if (temp.get_HeroSlot() == hero_slot)
        {
            return true;
        }
        else
            return false;
    }

    bool TwoChainCheck_Right()
    {
        Block temp = BlockManager.Instance.Listof_Blocks[block_slot - 1].GetComponent<Block>();
        if (temp.get_HeroSlot() == hero_slot)
        {
            return true;
        }
        else
            return false;
    }

    bool ThreeChainCheck_Left()
    {
        Block temp = BlockManager.Instance.Listof_Blocks[block_slot + 2].GetComponent<Block>();
        if (temp.get_HeroSlot() == hero_slot && TwoChainCheck_Left())
        {
            return true;
        }
        else
            return false;
    }

    bool ThreeChainCheck_Right()
    {
        Block temp = BlockManager.Instance.Listof_Blocks[block_slot - 2].GetComponent<Block>();
        if (temp.get_HeroSlot() == hero_slot && TwoChainCheck_Right())
        {
            return true;
        }
        else
            return false;
    }
}
