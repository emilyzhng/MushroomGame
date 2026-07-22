using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
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
    private int poisoned;
    private int nonpoisoned;
    public List<InventoryItem> items = new List<InventoryItem>();
    public LootSpawner spawner;
    public static bool goal1Met;
    public static bool goal2Met = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void addItem(MushroomScriptable mush)
    {
        Debug.Log("add item called" + items.Count);
        
        foreach(InventoryItem item in items)
        {
            if (item.data.mushroomName == mush.mushroomName)
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
            if (item.data.mushroomName == mush.mushroomName)
            {
                return item.numberof;
            }
        }
        return 0;
    }

    public void CheckPoison()
    {
        poisoned = 0;
        nonpoisoned = 0;
        foreach (InventoryItem mush in items)
        {
            if (mush.data.isPoisonous)
            {
                poisoned += mush.numberof;
            }
            else
            {
                nonpoisoned += mush.numberof;
            }
        }
    }

    public int ReturnPoisoned()
    {
        CheckPoison();
        return poisoned; 
    }

    public int ReturnNonpoisoned()
    {
       return nonpoisoned; 
    }

    public void ResetInventory()
    {
        items.Clear();
        if (items.Count == 0)
        {
            Debug.Log("Inv is empty");
        }
    }

    public String DayEndDisplay()
    {
        String display = "";
        if (items.Count == 0)
        {
            display = "Nothing!";
            return display;
        }
        foreach (InventoryItem item in items)
        {
        display += item.data.mushroomName + " x" + item.numberof + "\n";
        }
        return display;
    }

    public bool HasRequiredIngredients()
    {
        Debug.Log("Entered HasRequiredIngredients");
        goal1Met = returnNumberof(spawner.mushroomPrefabs[spawner.mushindex1].GetComponent<MushCategorization>().mushData) >= spawner.numgoal1;
        
    Debug.Log("Need: " + spawner.numgoal1);
        if (spawner.numgoal2 == 0)
        {
            Debug.Log("JJ" + goal1Met);
            return goal1Met;
        }

        goal2Met = returnNumberof(spawner.mushroomPrefabs[spawner.mushindex2].GetComponent<MushCategorization>().mushData) >= spawner.numgoal2;

        return goal1Met && goal2Met;
    }
}



