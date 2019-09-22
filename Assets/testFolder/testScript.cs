using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
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





    }
}
