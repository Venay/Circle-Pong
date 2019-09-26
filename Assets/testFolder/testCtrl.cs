using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCtrl : MonoBehaviour
{
    public Camera cam;
    public float speed = 50;
    public Rigidbody2D rb;
    Vector2 mousePosDelta, mousePosOld;
 

    // Update is called once per frame
    void Update()
    {
        /*
        mousePosDelta = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - mousePosOld;
        if (Input.GetMouseButton(0))
        {
            rb.AddTorque(Vector2.Dot(mousePosDelta, Vector2.right) * speed);
            //rb.angularVelocity = Vector2.Dot(mousePosDelta, Vector2.right) * speed;
            //print(Vector2.Dot(mousePosDelta, Vector2.right));
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            rb.AddTorque(Vector2.Dot(  (Vector2)cam.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition)       , Vector2.right) * speed);
        }

        print(Vector2.Dot(mousePosDelta, Vector2.right)*speed);


        mousePosOld = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        */



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                rb.angularVelocity = 0;

            if (touch.phase == TouchPhase.Moved)
                //rb.AddTorque(  Vector2.Dot(touch.deltaPosition, Vector2.right) );
                rb.angularVelocity = (  Vector2.Dot(touch.deltaPosition, Vector2.right) * speed );
        }

    }
}
