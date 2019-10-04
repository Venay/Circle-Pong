using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCtrl : MonoBehaviour
{
	public Camera cam;
	public float speed = 1;
	Vector2 mousePosOld, mousePosDelta = Vector2.zero;
	float rotX = 0;
	

	


	void Update()
	{

		mousePosDelta = mousePosOld - (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButton(0))
		{
			rotX = Vector2.Dot(Vector2.right.normalized, mousePosDelta.normalized);
			rotX = rotX * (mousePosDelta.magnitude / Time.deltaTime) * -speed;
		}

			print(rotX);
		transform.RotateAround(Vector3.zero, Vector3.forward, rotX);
		if (rotX >= 0)
			rotX = Mathf.Clamp(rotX - Time.deltaTime, 0, Mathf.Infinity);
		else
			rotX = Mathf.Clamp(rotX + Time.deltaTime, Mathf.NegativeInfinity, 0);
		


		mousePosOld = cam.ScreenToWorldPoint( Input.mousePosition );

	}

}
