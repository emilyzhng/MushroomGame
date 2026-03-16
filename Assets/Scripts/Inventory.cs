using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public MushroomScriptable data;
    public int numberof;

    public InventoryItem(MushroomScriptable data)
    {
        this.data = data;
        numberof = 1;
    }

}

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void addItem(MushroomScriptable mush)
    {
        Debug.Log("add item called" + items.Count);
        
        foreach(InventoryItem item in items)
        {
            if (item.data == mush)
            {
                item.numberof++;
                return;
            }

        }
        items.Add(new InventoryItem(mush));
        Debug.Log("add item called" + items.Count);
    }

    public int returnNumberof(MushroomScriptable mush)
    {
        foreach (InventoryItem item in items)
        {
            if (item.data == mush)
            {
                return item.numberof;
            }
        }
        return 0;
    }
}
