using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.UI;

public class MushInst : MonoBehaviour
{
    public GameObject InspectCam;
    public GameObject InspectBack;
    public GameObject PlayerCam;
    public GameObject InspectButton;
    public GameObject XButton;
    private GameObject InventoryMush;
    public GameObject Button;
    public GameObject CollectButton;
    public MushroomScriptable mushData;
    private GameObject currentMushroomPrefab;
    public PlayerMovement playerMovement;

    public Inventory playerInventory; 
    public InventoryUI inventoryUI;    
    public GameObject inv;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInventory = FindAnyObjectByType<Inventory>();
    }

    // Update is called once per frame
    public void SetMushroom(GameObject mushPrefab)
    {
        currentMushroomPrefab = mushPrefab;
    }

    public void MakeMush()
    {
        Debug.Log("works");
        if (currentMushroomPrefab == null) return;

        Vector3 BackPos = InspectBack.transform.position; 
        Vector3 Offset = new Vector3(0f, -0.5f, -5f);
        InventoryMush  = Instantiate(currentMushroomPrefab, BackPos+ Offset, Quaternion.identity);

        InspectCam.SetActive(true);
        PlayerCam.SetActive(false);
        InspectButton.SetActive(false);
        XButton.SetActive(true);
        CollectButton.SetActive(true);
        inv.SetActive(false);
        InspectBack.SetActive(true);
        
    }
    public void ExitInspect()
    {
        PlayerCam.SetActive(true);
        InspectCam.SetActive(false);
        XButton.SetActive(false);
        Destroy(InventoryMush);
        Button.SetActive(true);
        CollectButton.SetActive(false);
        inv.SetActive(true);
        InspectBack.SetActive(false);
    }
     public void PhysicalCollect()
    {
        MushCategorization mushroom = InventoryMush.GetComponent<MushCategorization>();
        playerInventory.addItem(mushroom.mushData);
        
        Destroy(InventoryMush);
        playerMovement.DestroyMush();
        InspectBack.SetActive(false);
        CollectButton.SetActive(false);
        XButton.SetActive(false);
        PlayerCam.SetActive(true);
        InspectCam.SetActive(false);
        inv.SetActive(true);
        InspectBack.SetActive(false);
        
        foreach (InventoryItem item in playerInventory.items)
        {
            Debug.Log("hello" + item.data.mushroomName + " x" + item.numberof);

        }

        inventoryUI.RefreshUI();
    
    }
   
}

