using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using System.ComponentModel.Design;
using Unity.Properties;

public class ButtonManager : MonoBehaviour
{
    public InventoryUI inventoryui;
    public Inventory inventory;
    public GameObject damper;
    public GameObject homeback;
    public GameObject hometext;
    public GameObject InspectCam;
    public GameObject PlayerCam;
    public GameObject SubmitButton;
    public GameObject NextDayButton;
    public GameObject NextButton;
    public TMP_Text DayText;
    public TMP_Text ObjectiveText;
    public TMP_Text ObjectiveDisplayText;
    public static int Day = 1;
    public static int ObjectiveIndex = 0;
    public TMP_Text DayReviewText;
    public Health healthclass;
    public GameObject homebackdaydisplay;
    public GameObject homebackbook;

    public string[] Objective = { "Collect 2 Cubes", "Collect 2 Spheres and 2 Cubes", "Collect 1 Cylinders, 2 Cubes, and 2 Spheres" };
    
    public void Start()
    {
        homeback.SetActive(false);
        if (Day <= 3)
        {
            DayText.text = "Day " + Day + "...";
        } 
        Debug.Log("H " + Day);

        ObjectiveText.text = Objective[ObjectiveIndex];
        ObjectiveDisplayText.text = Objective[ObjectiveIndex];  
    }

    public void ClickSubmit()
    {
        damper.SetActive(true);
        homeback.SetActive(true);
        InspectCam.SetActive(true);
        PlayerCam.SetActive(false);
        SubmitButton.SetActive(false);
        LeanTweenHandle.SlideInTB(homebackdaydisplay, 500, 2.5f);
        LeanTweenHandle.PopIn(homebackbook, 0.7f);

        TextMeshProUGUI tmpComponent = hometext.GetComponent<TextMeshProUGUI>();
        tmpComponent.text = inventory.DayEndDisplay();
        DayReviewText.text = "Day " + Day + " Review";

        inventoryui.DestoryUITracker();
    }

    public void ClickNext()
    {
        healthclass.isWrong();
        Debug.Log(inventory.ReturnPoisoned());
       if (inventory.ReturnPoisoned() > 0)
        {
            TextMeshProUGUI tmpComponent = hometext.GetComponent<TextMeshProUGUI>();
            tmpComponent.text = "You've Been Poisoned!";
            healthclass.isPoisoned();
        } else
        {
            TextMeshProUGUI tmpComponent = hometext.GetComponent<TextMeshProUGUI>();
            tmpComponent.text = "You were not poisoned!";
        }
        inventory.ResetInventory();

        NextDayButton.SetActive(true);
        NextButton.SetActive(false);
        LeanTweenHandle.FadeIn(NextDayButton, 0.6f);
    }


    public void ClickNextDay()
    {
        Day++;
        ObjectiveIndex++;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Debug.Log("Hello " + Day);
        if (Day == 4)
        {
            SceneManager.LoadScene("2ndVer"); 
        }
    }

}
    
