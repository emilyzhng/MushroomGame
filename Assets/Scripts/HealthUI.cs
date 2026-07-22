using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject[] hearts;
    public static HealthUI instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this one
        } else {
            Destroy(gameObject); // Destroy the duplicate
        }
    } 

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            Debug.Log("Worked");
            if (hearts[i] == null) continue;
            if (i < currentHealth)
            {
                hearts[i].SetActive(true); 
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}