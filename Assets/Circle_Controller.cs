using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
	[SerializeField] Camera cam;
	[SerializeField] Transform[] circles;
	[SerializeField] float dragSpeed = 1f;
	[SerializeField] float dragFade = 2;
	//public float t2 = 2;

	float angle;
	float swipeDrag = 0;

	float oldZ, oldDrag = 0;
	int countZ = 0;
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

			if ((touch.phase == TouchPhase.Moved) || (touch.phase == TouchPhase.Stationary))
			{
				V = Quaternion.AngleAxis(angle, Vector3.forward) * touchPos.normalized;
				countZ++;
			}

			if ((touch.phase == TouchPhase.Ended) || (touch.phase == TouchPhase.Canceled))
			{
				swipeDrag = -Mathf.DeltaAngle(transform.rotation.eulerAngles.z, oldZ)*countZ;
				countZ = 0;
			}
			
			oldZ = transform.rotation.eulerAngles.z;
			transform.up = V;
		}
		else
		{
			oldDrag = swipeDrag/dragFade;
			transform.RotateAround(transform.position, Vector3.forward, swipeDrag*Time.deltaTime * dragSpeed);
			swipeDrag = Mathf.Max(swipeDrag - oldDrag, 0);
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


}
