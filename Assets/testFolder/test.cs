﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class test : MonoBehaviour
{
	[Header("Components")]
	public LineRenderer line;
	public EdgeCollider2D col;

	[Header("Circle Settings")]
	public float radius = 1f;
	public int pointCount = 24;
	public float offset = 0;

	[Header("Circle Draw")]
	public bool loop;
	public float lineWidth = .1f;


	//Private Variables
	public struct point
	{
		public Vector3 position;
		public int index;
		public float theta;
	}

	List<point> points = new List<point>();
	Vector2[] circlePositions2D;
	Vector3[] circlePositions;



	float deltaTheta()
	{
		return (2 * Mathf.PI) / pointCount;
	}


	void circleLoad()
	{

		float theta = 0;
		for (int i = 0; i < pointCount; i++)
		{

			point P;
			P.index = i;
			P.theta = theta;
			P.position = new Vector3(radius * Mathf.Cos(theta + offset * Mathf.Deg2Rad), radius * Mathf.Sin(theta + offset * Mathf.Deg2Rad), 0);
			circlePositions[i] = P.position;
			circlePositions2D[i] = (Vector2)P.position;
			points.Add(P);
			theta += deltaTheta();
		}


	}


	void drawCircle()
	{
		circlePositions = new Vector3[pointCount];
		if (loop)
			circlePositions2D = new Vector2[pointCount + 1];
		else
			circlePositions2D = new Vector2[pointCount];

		points.Clear();
		circleLoad();
		//circlePositions().Clear();
		//circlePositions2D().Clear();


		if (loop)
			circlePositions2D[circlePositions2D.Length - 1] = circlePositions2D[0];

		line.loop = loop;
		line.startWidth = line.endWidth = lineWidth;
		line.positionCount = circlePositions.Length;
		line.SetPositions(circlePositions);




		col.edgeRadius = lineWidth / 2;
		col.points = circlePositions2D;


	}

	private void Start()
	{
		drawCircle();
	}


	private void OnValidate()
	{
		drawCircle();
	}


}