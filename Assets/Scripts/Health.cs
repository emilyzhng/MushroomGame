using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public HealthUI playerUI;
    public int maxHealth = 4;
    public static int currentHealth = 0;
    public static Health instance;
    public DailyEffects effects;
    public static bool poisoned;
    public Inventory inventory;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this one
        } else {
            Destroy(gameObject); // Destroy the duplicate
        }
    } 

    void Start()
    {
        if (currentHealth == 0) {
            currentHealth = maxHealth;
        }
        Debug.Log("Current Health: " + currentHealth);
        playerUI.UpdateHearts(currentHealth);
        Debug.Log("Poisoned Status: " + poisoned);
        if (poisoned == true)
        {
            Debug.Log("Huzzah");
            effects.RandomEffect();

            poisoned = false;
        }
    }

    public void isPoisoned()
    {
        currentHealth--;
        Debug.Log("Current Health: " + currentHealth);
        playerUI.UpdateHearts(currentHealth);
        poisoned = true;
        Debug.Log("Poisoned Status " + poisoned);
    }

    public void isWrong()
    {
        inventory.HasRequiredIngredients();
        
        {
            
        }
        if (ButtonManager.Day == 1 && !Inventory.goal1Met)
        {
            currentHealth--;
        }

        if (ButtonManager.Day == 2 && !Inventory.goal2Met)
        {
            currentHealth--;
        }

        if (ButtonManager.Day == 3 && (!Inventory.goal2Met || !Inventory.goal1Met))
        {
            currentHealth--;
        }
        playerUI.UpdateHearts(currentHealth);
    }


    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}