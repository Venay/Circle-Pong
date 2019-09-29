using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CriticalObject : MonoBehaviour
{
	


	private void OnTriggerEnter2D(Collider2D col)
	{		
		if (col.tag == "Player")
		{
			GameManager.isInsideCrit = true;
		}
	}



	


}
