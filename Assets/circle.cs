using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class circle : MonoBehaviour
{
	[Header("components")]
	[SerializeField] private LineRenderer line;
	[SerializeField] private EdgeCollider2D col;

	[Header("Circle Setup")]
	[SerializeField] float radius = 2;
	[SerializeField] int resolution = 24;
    [SerializeField] float offset = 0;
	int pointCount () { return resolution + 1; }
	float deltaTheta() {  return (2 * Mathf.PI) / resolution ; }
	Vector2[] points;

	[Header("Circle Draw")]
	[SerializeField] float lineWidth = .1f;
	[SerializeField] int capResolution = 5;

	[Header("Slice")]
	[SerializeField][Range(0, 1)] float startSlice;
    [SerializeField][Range(1, 0)] float endSlice;
    int startSliceIndex () { return (startSlice >= endSlice) ? Mathf.RoundToInt(Mathf.Max(startSlice , endSlice) * 360 * Mathf.Deg2Rad / deltaTheta()) :  Mathf.RoundToInt(startSlice * 360 * Mathf.Deg2Rad / deltaTheta()); }
    int endSliceIndex () { return (startSlice >= endSlice) ? Mathf.RoundToInt(Mathf.Max(startSlice, endSlice) * 360 * Mathf.Deg2Rad / deltaTheta()) : Mathf.RoundToInt(endSlice * 360 * Mathf.Deg2Rad / deltaTheta()); }

	[Header("Game Manager")]
	[SerializeField] int currentIndex = 0 ;
    public Vector3 circleIdentifier() { return new Vector3(radius, startSlice * 360 * Mathf.Deg2Rad, endSlice * 360 * Mathf.Deg2Rad); }


	void circleSetup()
	{
		
		points = new Vector2[pointCount()];

		float theta = 0;
		float thetaDiff = startSlice * 360 * Mathf.Deg2Rad - deltaTheta() * startSliceIndex();


		for (int i = 0; i < points.Length; i++)
		{
			if (i == pointCount() - 1 )
			{
				points[i] = new Vector2(radius * Mathf.Cos(offset * Mathf.Deg2Rad), radius * Mathf.Sin(offset * Mathf.Deg2Rad) );
				
			} else if ( i == startSliceIndex() )
			{
				points[i] = new Vector2(radius * Mathf.Cos(theta + thetaDiff + offset * Mathf.Deg2Rad), radius * Mathf.Sin(theta + thetaDiff + offset * Mathf.Deg2Rad));
				theta += deltaTheta();
			}
			else
			{
				points[i] = new Vector2(radius * Mathf.Cos(theta + offset * Mathf.Deg2Rad), radius * Mathf.Sin(theta + offset * Mathf.Deg2Rad));
				theta += deltaTheta();
			}
		}

		

	}



	void circleDraw()
	{

		int sS = startSliceIndex();
		int eS = endSliceIndex();
		
		int j = 0;

		circleSetup();

		Vector2[] colPos = new Vector2[(eS - sS) + 1];
		Vector3[] linePos = new Vector3[(eS - sS) + 1];
		

		for (int i = sS; i <= eS ; i++)
		{
			linePos[j] = points[i];
			colPos[j] = points[i];
			j++;
		}
		//print(eS + " - " + sS + " = " + (eS-sS) + "  :  " + linePos.Length);


		if ((startSlice == 0) && (endSlice == 1))
			line.loop = true;
		else
			line.loop = false;

		line.startWidth = line.endWidth = lineWidth;
		line.numCapVertices = capResolution;

		line.positionCount = linePos.Length;
		line.SetPositions(linePos);





		col.edgeRadius = lineWidth / 2;
		col.points = colPos;


        



    }


	private void Start()
	{
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
        circleDraw();
		
	}


    
    private void OnValidate()
	{
        
		circleDraw();
		
	}
    


    private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		int foo = 0;
		
		Vector2 oldPos = points[0];
		
		for (int i = 1; i < points.Length; i++)
		{
			Gizmos.DrawLine(oldPos, points[i]);
			if ((i >= startSliceIndex() ) && ( i <= endSliceIndex()))
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(points[i], deltaTheta() / (1 / radius) / 3);
				Gizmos.color = Color.red;
				foo++;
			}
			else
			{
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(points[i], deltaTheta() / (1 / radius) / 9);
				Gizmos.color = Color.red;
			}
			oldPos = points[i];
		}

		//print(foo + "  ---  " + (endSliceIndex()  - startSliceIndex() ));
		



	}



}
