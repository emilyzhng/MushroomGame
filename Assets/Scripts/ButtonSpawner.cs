using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject spawned;
    public GameObject button;
    public GameObject canvas;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && spawned == null)
        {
         spawned = Instantiate(button, canvas.transform);
         }
    }
}
