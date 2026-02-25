using UnityEngine;

public class Inspect : MonoBehaviour
{
    public Transform objectInspect;
    public float rotationSpeed= 0.2f;
    private Vector3 Prev;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Prev = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - Prev;
            float RotationX = deltaMousePosition.y * rotationSpeed *  Time.deltaTime;
            float RotationY = -deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(RotationX,RotationY,0);
            objectInspect.rotation = rotation * objectInspect.rotation;

            Prev = Input.mousePosition;

        }
    }
}
