using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePong_Controller : MonoBehaviour
{
	public static int direc = 1;


	public Camera cam;
	public Transform ponger, bin;
	public float dragSpeed = 20f;
	


	Touch tooch;
	float rotationDrag = 0f;
	Vector3 downPos, upPos, currentPos;
	

    // Update is called once per frame
    void Update()
    {
		if (Input.touchCount > 0)
		{

			tooch = Input.GetTouch(0);

			print("touching");

		}

		//Touch Starting ------------------------------------------------------------------
		if (tooch.phase == TouchPhase.Began)
		{
			downPos = tooch.position;
			//Debug.Log("Down : " + downPos.x);
			currentPos = cam.ScreenToWorldPoint(tooch.position) + new Vector3(0, 0, 10);
			
			transform.up = (cam.ScreenToWorldPoint(tooch.position) + new Vector3(0, 0, 10) - transform.position).normalized;
			//StartCoroutine(rotateTo(60, currentPos));
			
			ponger.SetParent(transform, true);
		}



		//Touching ---------------------------------------------------------------------
		if (tooch.phase == TouchPhase.Moved)
		{
			//currentPos = cam.ScreenToWorldPoint(tooch.position) + new Vector3(0, 0, 10);
			//StartCoroutine(rotateTo(2, currentPos));
			if (ponger.parent != transform)
				ponger.SetParent(transform, true);

			transform.up = (cam.ScreenToWorldPoint(tooch.position) + new Vector3(0, 0, 10) - transform.position).normalized;



		}


		//Touch Ending ------------------------------------------------------------------
		if (tooch.phase == TouchPhase.Ended)
		{
			
			upPos = tooch.position;
			
			rotationDrag = (cam.ScreenToWorldPoint(upPos) - cam.ScreenToWorldPoint(downPos)).magnitude;

			
			if (upPos.x - downPos.x >= 0)
				direc = 1;
			else
				direc = -1;
			

			


		}



		if(Input.touchCount == 0)
		{
			
			ponger.Rotate(ponger.forward, direc * (Time.deltaTime * 20 + rotationDrag));
		}

		rotationDrag = Mathf.Clamp(rotationDrag - Time.deltaTime, 0, Mathf.Infinity);


    }


	IEnumerator rotateTo(int frames, Vector3 too)
	{
		Vector3 oldup = transform.up;
		for (int i = 1; i == frames; i++)
		{
			transform.up = Vector3.Lerp(oldup, (too - transform.position).normalized , i/frames);
			yield return null;
		}
	}


}
