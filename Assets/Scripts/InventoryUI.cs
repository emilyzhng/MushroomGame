using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory; 
    public GameObject itemPrefab;     
    public Transform Grid;    

    private Dictionary<MushroomScriptable, GameObject> UITracker = new Dictionary<MushroomScriptable, GameObject>();

    public void RefreshUI()
    {
        foreach (var item in playerInventory.items)
        {
            UpdateItemUI(item.data, item.numberof);
        }
    }

    private void UpdateItemUI(MushroomScriptable mush, int quantity)
    {
        if (UITracker.ContainsKey(mush))
        {
            TextMeshProUGUI quantityText = UITracker[mush].transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            quantityText.text = "x" + quantity;
        }
        else
        {
            GameObject go = Instantiate(itemPrefab, Grid);
            
            Image icon = go.transform.GetChild(0).GetComponent<Image>();
            icon.sprite = mush.icon;

            TextMeshProUGUI quantityText = go.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            quantityText.text = "x" + playerInventory.returnNumberof(mush);

            UITracker[mush] = go;
        }
    }
}