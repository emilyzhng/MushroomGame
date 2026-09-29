
using UnityEngine;


public class Health : MonoBehaviour
{
    public HealthUI playerUI;
    public int maxHealth = 1;
    public static int currentHealth = 4;
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
        currentHealth = currentHealth - 2;
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
            currentHealth-= 0;
            Debug.Log("Hello " + currentHealth);
        }

        if (ButtonManager.Day == 2 && !Inventory.goal2Met)
        {
            currentHealth-= 0;
        }

        if (ButtonManager.Day == 3 && (!Inventory.goal2Met || !Inventory.goal1Met))
        {
            currentHealth-= 2;
        }
        playerUI.UpdateHearts(currentHealth);
    }


    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}