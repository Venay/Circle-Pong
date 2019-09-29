using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
	[SerializeField] Camera cam;
	[SerializeField] float speed = 1f;
	[SerializeField] Transform[] circles;
	public float t = 2;
	public float t2 = 2;

	float angle;
	int direction = 1;
	float swipeDrag = 0;

	Vector2 oldMousePos, deltaMousePos = Vector2.zero;




	private void Update()
	{

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = (Vector2)cam.ScreenToWorldPoint(touch.position);
			
			Vector2 V = transform.up;

			if (touch.phase == TouchPhase.Began)
			{
				angle = getAngle2D(V, touchPos.normalized);

				if (Vector2.Dot(transform.right, touchPos.normalized) < 0)
					angle *= -1;
			}

			if (touch.phase == TouchPhase.Moved)
			{

				V = Quaternion.AngleAxis(angle, Vector3.forward) * touchPos.normalized;

			}

			if (touch.phase == TouchPhase.Ended)
			{
				direction = Mathf.RoundToInt(Vector2.Dot(Vector2.right, touch.deltaPosition.normalized));
				if (direction == 0) { direction = 1; }
				swipeDrag = touch.deltaPosition.magnitude / Time.deltaTime;
			}

			transform.up = V;


		}else if (Input.GetMouseButton(0))
		{
			Vector2 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
			deltaMousePos = mousePos - oldMousePos;
			Vector2 V = transform.up;
			

			if (Input.GetMouseButtonDown(0))
			{
				angle = getAngle2D(V, mousePos.normalized);

				if (Vector2.Dot(transform.right, mousePos.normalized) < 0)
					angle *= -1;
				
			}

			V = Quaternion.AngleAxis(angle, Vector3.forward) * mousePos.normalized;
			//V = Quaternion.AngleAxis(deltaMousePos.magnitude, Vector3.forward) * V;

			if (Input.GetMouseButtonUp(0))
			{
				direction = Mathf.RoundToInt(Vector2.Dot(Vector2.right, deltaMousePos.normalized));
				if (direction == 0) { direction = 1; }
				swipeDrag = deltaMousePos.magnitude / Time.deltaTime;
			}

			oldMousePos = mousePos;
			transform.up = V;

		}
		else
		{
			transform.Rotate(Vector3.forward, t2 * Time.deltaTime + (swipeDrag * Time.deltaTime * speed) * direction);
			swipeDrag = Mathf.Clamp(swipeDrag - t * Time.deltaTime, 0, 2000);

		}


		


		foreach (Transform T in circles)
		{
			if (T.tag == "+1")
				T.rotation = transform.rotation;
			else
				T.rotation = Quaternion.Inverse(transform.rotation);
		}




	}

	float getAngle2D(Vector2 V1, Vector2 V2)
	{
		return Mathf.Acos(Vector2.Dot(V1, V2) / (V1.magnitude * V2.magnitude)) * Mathf.Rad2Deg;
	}







	#region
	/*
    void FixedUpdate()
    {

        




        if(Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            


            if (touch.phase == TouchPhase.Began) 
            {
                
                foreach (Rigidbody2D rb in RBs)
                {
                    rb.angularVelocity = 0f;
                }


            }


            if (touch.phase == TouchPhase.Moved) 
            {

                

                for (int i = 0; i < RBs.Length; i++)
                {
                    
                    //RBs[i].AddTorque(Vector2.Dot(Vector2.right, mousePosDelta) * directions[i] * dragSpeed);
                    RBs[i].angularVelocity = Vector2.Dot(Vector2.right, touch.deltaPosition.normalized) * directions[i] * dragSpeed;
                    //RBs[i].angularDrag = 0;

                    
                }

                

            }



            if (touch.phase == TouchPhase.Ended)
                foreach (Rigidbody2D rb in RBs)
                    rb.angularDrag = angulaDrag;



        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < RBs.Length; i++)
                {
                    RBs[i].angularVelocity = 0;
                }
            }




            if (Input.GetMouseButton(0))
            {

                mousePosDelta = (Vector2)Input.mousePosition - mousePosOld;

                for (int i = 0; i < RBs.Length; i++)
                {
                    RBs[i].angularVelocity = Vector2.Dot(Vector2.right, mousePosDelta) * directions[i]  ;
                }

                mousePosOld = Input.mousePosition;

            }
        }

        print(RBs[0].angularDrag);

    }
    */
	#endregion

}
