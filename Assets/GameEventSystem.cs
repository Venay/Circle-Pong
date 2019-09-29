using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventSystem : MonoBehaviour
{
	#region
	public static GameEventSystem current;
	private void Awake()
	{
		current = this;
	}
	#endregion


	public event Action onBallHit;
	public void ballHit()
	{
		if (onBallHit != null)
			onBallHit();
	}




}
