using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
     * Controls movement of the player
     */
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDir;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }


    private void FixedUpdate()
    {
        movePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal: A (-1), D(1)
        //Vertical: W(-1), S(1)

        //the signs are wonky because in Cam, the transform.rotation has a -90 
        //to make player face the right direction upon entering.
        horizontalInput = -Input.GetAxisRaw("Vertical");
        verticalInput = Input.GetAxisRaw("Horizontal");

        speedLimit();
    }

    private void movePlayer()
    {
        //forward movement is in direction player is facing
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;


        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
    }

    private void speedLimit()
    {
        Vector3 v = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (v.magnitude > speed)
        {
            Vector3 maxV = v.normalized * speed;
            rb.velocity = new Vector3(maxV.x, 0f, maxV.z);
        }
    }

}
