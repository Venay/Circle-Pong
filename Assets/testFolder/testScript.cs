using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
<<<<<<< HEAD
	public Camera cam;
	public Rigidbody2D rb;
	public float force = 1;
	public ForceMode2D forcemode;



	private void FixedUpdate()
	{
		

		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(slamForward(.5f, cam.ScreenToWorldPoint(Input.mousePosition)));
=======
	public Transform square, bin;
	bool inBin = false;

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown(0))
		{
			if (inBin)
			{
				square.SetParent(transform);
				inBin = !inBin;
			}
			else
			{
				square.SetParent(bin);
				inBin = !inBin;
			}
		}

>>>>>>> parent of 07d542e... Correct Controls



		}

<<<<<<< HEAD
		

	}



	IEnumerator slamForward(float damping, Vector2 direction)
	{
		rb.AddForce(direction.normalized * force, forcemode);
		print("force added");
		while (rb.velocity.magnitude > 0)
		{
			Vector2 V = rb.velocity;
			V.x = Mathf.Clamp(V.x * damping, 0, Mathf.Infinity);
			V.y = Mathf.Clamp(V.y * damping, 0, Mathf.Infinity);
			rb.velocity = V;
			if (rb.velocity.magnitude <= .01f)
				rb.velocity = Vector2.zero;

			print("damping");
			yield return null;
		}


	}

=======
    }
>>>>>>> parent of 07d542e... Correct Controls
}
