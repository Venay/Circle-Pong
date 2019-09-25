using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePong_Controller : MonoBehaviour
{
    public static int direc = 1;


    public Camera cam;
    public float rotationSpeed = 1;
    public int swipeFadeDamping = 10;


    Vector3 V = Vector3.up;
    float angle, swipeFade = 0;
    Vector3 touchPos = Vector3.zero;
    Touch touch;
    int direction = 1;



    // Update is called once per frame
    void Update()
    {



        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            touchPos = cam.ScreenToWorldPoint(touch.position) + new Vector3(0, 0, 10);


            if (touch.phase == TouchPhase.Began)
            {
                angle = getAngle2D(V, touchPos.normalized);


                if (Vector3.Dot(transform.right, touchPos.normalized) < 0)
                    angle *= -1;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                V = touchPos.normalized;
                V = Quaternion.AngleAxis(angle, Vector3.forward) * V;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                direction = Mathf.RoundToInt(Vector3.Dot(Vector3.right, touch.deltaPosition.normalized));
                swipeFade = touch.deltaPosition.magnitude;



            }


            transform.up = V;

        }
        else
        {
            transform.Rotate(Vector3.forward, direction * ((Time.deltaTime * rotationSpeed) + Mathf.Clamp(swipeFade / swipeFadeDamping, 0, 50)), Space.World);

            Debug.Log(swipeFade);
            swipeFade -= Time.deltaTime * 30;
            V = transform.up;
        }








    }



    float getAngle2D(Vector2 V1, Vector2 V2)
    {
        return Mathf.Acos(Vector2.Dot(V1, V2) / (V1.magnitude * V2.magnitude)) * Mathf.Rad2Deg;
    }





}

