using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
	[SerializeField] Camera cam;
	[SerializeField] Transform[] circles;
	[SerializeField] float smoothAngle = .3f;
	//public float t2 = 2;

	float angle,angleOld,angleDelta,angleRef;
	




	private void Update()
	{
		//----------------------------------------
		// TOUCH CONTROLS
		//----------------------------------------
		if (Input.touchCount > 0)  
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = (Vector2)cam.ScreenToWorldPoint(touch.position);


			if (touch.phase == TouchPhase.Began)
			{
				angle = getAngle2D(transform.up, touchPos.normalized) * Mathf.Sign(Vector2.Dot(transform.right, touchPos.normalized));
			}
			else if ((touch.phase == TouchPhase.Moved) || (touch.phase == TouchPhase.Stationary))
			{
				Vector2 V = Quaternion.AngleAxis(angle, transform.forward) * touchPos.normalized;
				transform.up = V;
				angleDelta = Mathf.DeltaAngle(angleOld, transform.localEulerAngles.z);
				angleOld = transform.localEulerAngles.z;
			}
		}
		//----------------------------------------
		// MOUSE CONTROLS
		//----------------------------------------
		else if (Input.GetMouseButton(0))
		{
			Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0))
			{
				angle = GameManager.getAngle2D(transform.up, mousePos.normalized) * Mathf.Sign(Vector2.Dot(transform.right, mousePos.normalized));
			}
			Vector2 V = Quaternion.AngleAxis(angle, transform.forward) * mousePos.normalized;
			transform.up = V;
			angleDelta = Mathf.DeltaAngle(angleOld, transform.localEulerAngles.z);
			angleOld = transform.localEulerAngles.z;
		}
		//----------------------------------------
		// DRAG SETTINGS
		//----------------------------------------
		else
		{
			transform.RotateAround(transform.position, transform.forward, angleDelta);
			angleDelta = Mathf.SmoothDampAngle(angleDelta, 0, ref angleRef, smoothAngle);
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
