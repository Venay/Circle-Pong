using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCtrl : MonoBehaviour
{
	public Camera cam;
	public float speed = 1;
	Vector2 oldMousePos, deltaMousePos = Vector2.zero;
	float swipeDrag = 0;
	

	


	void Update()
	{

		deltaMousePos = oldMousePos - (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButton(0))
		{
			swipeDrag = Vector2.Dot(Vector2.right.normalized, deltaMousePos.normalized);
			swipeDrag = swipeDrag * (deltaMousePos.magnitude / Time.deltaTime) * -speed;
		}

		
		transform.RotateAround(Vector3.zero, Vector3.forward, swipeDrag);
		if (swipeDrag >= 0)
			swipeDrag = Mathf.Clamp(swipeDrag - Time.deltaTime, 0, Mathf.Infinity);
		else
			swipeDrag = Mathf.Clamp(swipeDrag + Time.deltaTime, Mathf.NegativeInfinity, 0);
		


		oldMousePos = cam.ScreenToWorldPoint( Input.mousePosition );

	}

}
