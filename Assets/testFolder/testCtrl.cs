using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testCtrl : MonoBehaviour
{
	public Camera cam;
	public float smoothAngle, dragPower = .3f;
	public bool isRadial = true;
	float angle, angleOld, angleDelta, angleRef;
	Vector2 mousePosOld, mousePosDelta = Vector2.zero;

	void Update()
	{



		Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePosDelta = mousePos - mousePosOld;
		if (Input.GetMouseButton(0))
		{



			
			float rotX = (mousePosDelta.magnitude / Time.deltaTime) * dragPower * -Mathf.Sign(mousePos.y) * Mathf.Sign(Vector2.Dot(Vector2.right, mousePosDelta));

			transform.Rotate(Vector3.forward, rotX);


			
			angleDelta = Mathf.DeltaAngle(angleOld, transform.localEulerAngles.z);
			angleOld = transform.localEulerAngles.z;


		}
		else
		{
			//mousePosOld = Vector2.zero;
			transform.RotateAround(transform.position, transform.forward, angleDelta);
			angleDelta = Mathf.SmoothDampAngle(angleDelta, 0, ref angleRef, smoothAngle);
		}

		mousePosOld = mousePos;

	}

	Vector2 rotated2D(Vector2 V, float a)
	{
		return new Vector2(V.x * Mathf.Cos(a) - V.y * Mathf.Sin(a), V.x * Mathf.Sin(a) + V.y * Mathf.Cos(a));
	}

}
