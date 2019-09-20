using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotate : MonoBehaviour
{
    public float dragSpeed = 20;
    public Camera cam;

    private void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rotX = Input.GetAxis("Mouse X") * Mathf.Deg2Rad*dragSpeed;
        

        if (Input.GetMouseButton(0))
            if (mousePos.y <= 0)
                transform.RotateAround(Vector3.forward, rotX);
            else
                transform.RotateAround(Vector3.forward, -rotX);

        transform.Rotate(transform.forward, dragSpeed * Time.deltaTime, Space.World);
    }

    /*
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * Mathf.Deg2Rad * speed;
        
        transform.RotateAround(Vector3.forward, rotX);
        
    }
    */

}
