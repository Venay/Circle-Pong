using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCtrl : MonoBehaviour
{
	public Camera cam;
	public Rigidbody2D rb;
	float angle, oldAngle, deltaAngle;

	public enum controlTypes {radial, horizontal, vertical }
	public controlTypes control;
	

	void Update()
	{
		Debug.DrawLine(rb.transform.position, rb.transform.right);
		Debug.DrawLine(rb.transform.position, rb.transform.up, Color.blue);


		Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 V = rb.transform.up;

		
		

		if (Input.GetMouseButtonDown(0))
		{
			rb.angularVelocity = 0;
			angle = GameManager.getAngle2D(V, mousePos.normalized)*Mathf.Sign(Vector2.Dot(rb.transform.right, mousePos.normalized));

		}

		if (Input.GetMouseButton(0))
		{
			V = Quaternion.AngleAxis(angle, Vector3.forward) * mousePos.normalized;
			rb.transform.up = V;
			deltaAngle = Mathf.DeltaAngle(transform.localEulerAngles.z, oldAngle);
			oldAngle = transform.localEulerAngles.z;
		}

		if (Input.GetMouseButtonUp(0))
		{
			print(deltaAngle/Time.deltaTime);
			rb.angularVelocity = -deltaAngle / Time.deltaTime;
		}

		
		

	}


}
