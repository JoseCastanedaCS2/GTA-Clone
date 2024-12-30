using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;
    public bool invertXRotaiton;
    private float curXRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //set variables for mouse input
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //set the left and right rotation
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        //set the up and down rotation and have it inverted if wanted
        if (invertXRotaiton)
            curXRot += y * lookSensitivity;
        else
            curXRot -= y * lookSensitivity;

        //clamp the up and down rotation so the player isnt able to continue past a certain point
        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        //create a temp variable and assigning it to our camAnchor and assigning the X axis to our curXRot
        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;

        //apply the new variable to the camera's rotation
        camAnchor.eulerAngles = clampedAngle;
    }
}
