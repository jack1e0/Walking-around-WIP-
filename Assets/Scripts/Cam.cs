using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam : MonoBehaviour
{
    /*
     * Controls rotation of viewport, simulates first-person head rotation
     */
    
    //sensitivities of X and Y
    [SerializeField]
    private int sensX;

    [SerializeField]
    private int sensY;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    void Start()
    {
        //ensure cursor locked in middle of screen, and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //limit max angle to respective degrees up and down
        xRotation = Mathf.Clamp(xRotation, -70f, 80f);

        //rotate cam about both axes
        transform.rotation = Quaternion.Euler(xRotation, yRotation - 90f, 0);

        //rotate player about y-axis (vertical)
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
