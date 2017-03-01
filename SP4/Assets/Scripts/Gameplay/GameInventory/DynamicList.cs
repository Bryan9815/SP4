using UnityEngine;
using System.Collections;

public class DynamicList : MonoBehaviour {

    public GameObject itemPrefab;
    public static int itemCount;
    public int columnCount = 1;

    void Start()
    {
        itemCount = WeaponSelect.theWeapons.Count;
        Debug.Log(itemCount);
        //calculate the width and height of each child item.
        int rowCount = itemCount / columnCount;
        if (itemCount % rowCount > 0)
            rowCount++;

        int j = 0;
        for (int i = 0; i < itemCount; i++)
        {
            //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
            if (i % columnCount == 0)
                j++;

            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            newItem.name = gameObject.name + " item at (" + i + "," + j + ")";
            newItem.transform.SetParent(gameObject.transform, false);

            //move and size the new item
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        }
    }
}
