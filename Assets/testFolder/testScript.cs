using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public Camera cam;
    Vector3 V = Vector3.up;
    float angle = 0;
    void Update()
    {
        Vector3 mousePos = (cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10));

        if (Input.GetMouseButtonDown(0))
        {
            angle = getAngle2D(V, mousePos.normalized);

            
            if ( Vector3.Dot(transform.right, mousePos.normalized) < 0)
                angle *= -1;
            Debug.Log(angle);
                
        }


        if (Input.GetMouseButton(0))
        {
            V = mousePos.normalized;
            V = Quaternion.AngleAxis(angle, Vector3.forward) * V;
        }

            transform.up = V;
        if (Input.GetMouseButtonDown(1))
        {
            V = Vector3.up;
        }



        
    }

    float getAngle2D(Vector2 V1, Vector2 V2)
    {
        return Mathf.Acos(Vector2.Dot(V1, V2) / (V1.magnitude * V2.magnitude)) * Mathf.Rad2Deg;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, V);
    }

}
