using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
   private float movementX;
   private float movementY;
   public float speed = 10;
   public float jump = 13;
   public Boolean jreq;
   public float gravity;
   public GameObject button;
   public GameObject canvas;
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        jreq = false;
        rb.useGravity = false;
        gravity = -50;
        jump = 20;
        button.SetActive(false);
    }

    void OnMove (InputValue movementValue)
    {
       Vector2 movementVector = movementValue.Get<Vector2>();

       movementX = movementVector.x;
       movementY = movementVector.y;
    

    }
   private void FixedUpdate()
    {
        Vector3 camForward = Camera.main.transform.forward; 
        Vector3 camRight = Camera.main.transform.right; camForward.y = 0; 
        camRight.y = 0; 


        Vector3 move = camForward * movementY + camRight * movementX; 
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);


        if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Vector3.up * gravity/2, ForceMode.Acceleration);
        }
    }
    

     // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jreq)
        {
            rb.linearVelocity = new Vector3(movementX, jump ,movementY);
            jreq = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            jreq = true;
        }

        if (other.CompareTag("mushroom"))
        {
            Debug.Log("enter premise");
            button.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mushroom"))
        {
            Debug.Log("exitspawned premise");
            button.SetActive(false);
        }
    }
}
