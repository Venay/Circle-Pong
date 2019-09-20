using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CirclePongController : MonoBehaviour
{
    public Camera cam;

    Vector2 mouseDownPosition;
    Vector2 mouseUpPosition;
    bool firstMousePress = true;
    public float dragSpeed = 20;
    public float rotationSpeed = 2;
    float rotationDamping = 0;


    Vector3 mouseDeltaPosition = Vector3.zero;
    Vector3 mouseOldPosition = Vector3.zero;
    bool direction;


    private void Update()
    {
        
        mouseDeltaPosition = Input.mousePosition - mouseOldPosition;


        if ((Input.GetMouseButtonDown(0) && firstMousePress)){
            mouseDownPosition = Input.mousePosition;
            firstMousePress = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstMousePress = true;
            mouseUpPosition = Input.mousePosition;
            direction =  (mouseUpPosition.x - mouseDownPosition.x) >= 0;
            //Debug.Log(direction);
            rotationDamping = Mathf.Abs((mouseUpPosition.x - mouseDownPosition.x));
        }


        



        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rotX = Input.GetAxis("Mouse X") * Mathf.Deg2Rad * dragSpeed;
        


        if (Input.GetMouseButton(0))
            if (mousePos.y <= 0)
                transform.RotateAround(Vector3.forward, rotX);
            else
                transform.RotateAround(Vector3.forward, -rotX);
        else
            if (direction)
                transform.Rotate(transform.forward, Time.deltaTime * (rotationSpeed + Mathf.Clamp((rotationDamping), 0, Mathf.Infinity)), Space.World);
            else
                transform.Rotate(transform.forward, -Time.deltaTime * (rotationSpeed + Mathf.Clamp((rotationDamping), 0 , Mathf.Infinity)), Space.World);

        

        rotationDamping -= Time.deltaTime * 70;
        
        mouseOldPosition = Input.mousePosition;
    }


    


    


}
