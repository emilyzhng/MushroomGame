using UnityEngine;

public class MushTrigger : MonoBehaviour
{
    public GameObject inspectPrefab;
    public MushInst inspectSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inspectSystem.SetMushroom(inspectPrefab);
            inspectSystem.InspectButton.SetActive(true);
        }
    }
}