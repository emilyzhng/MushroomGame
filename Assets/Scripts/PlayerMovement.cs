
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
   private float movementX;
   private float movementY;
    public float moveSpeed = 10;
    public float jumpForce = 13;
   public bool jreq;
   public float gravity;
   public GameObject button;
   public GameObject canvas;
   public GameObject currentmush;
   
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 10;
        jreq = false;
        rb.useGravity = false;
        gravity = -50;
        jumpForce = 20;
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
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);

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
            rb.linearVelocity = new Vector3(movementX, jumpForce, movementY);
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
            Debug.Log("hello enter premise");
            currentmush = other.gameObject.transform.parent.gameObject;
            Debug.Log("hello Stored mushroom: " + currentmush.name);
            button.SetActive(true);
        }

    }

    public void DestroyMush()
    {
        Debug.Log("not destroyed printed");
        Debug.Log("Current mush is: " + currentmush);

        if (currentmush != null)
        {
            Debug.Log("destroyed printed");
            Destroy(currentmush);
            currentmush = null;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mushroom"))
        {
            Debug.Log("exitspawned premise");
            button.SetActive(false);
            currentmush = null;
        }
    }
}
