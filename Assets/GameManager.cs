using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("statics")]
	public static int score;
	public static int hightScore;
	[SerializeField] int circlesCount = 1;
	public static Vector2[][] circlePoints = new Vector2[1][];

	private void Awake()
	{
		circlePoints = new Vector2[circlesCount][];
		for (int i = 0; i < circlesCount; i++)
		{
			circlePoints[i] = new Vector2[0];
		}
	}
	private void Start()
	{
		Debug.Log(circlePoints.Length);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			int f = Random.Range(0, circlePoints.Length);
			Debug.DrawLine(Vector2.zero, circlePoints[f][Random.Range(0, circlePoints[f].Length)] , Color.cyan, 1);
		}
	}


}
