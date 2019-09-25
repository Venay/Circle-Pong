using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCtrl : MonoBehaviour
{
    public Camera cam;
    public float speed = 50;
    Vector2 mousePosOld, mousePosDelta = Vector2.zero;

 

    // Update is called once per frame
    void Update()
    {

        //Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButton(0))
        {
            mousePosDelta = (Vector2)Input.mousePosition - mousePosOld;

            transform.Rotate(Vector3.forward,  Vector2.Dot(mousePosDelta, Vector3.right) * speed, Space.World);

            


            mousePosOld = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            print(Input.mousePosition.y <= Screen.height / 4);
        }

    }
}
