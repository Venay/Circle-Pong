using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class circle : MonoBehaviour
{
    [Header("Animation")]
    public bool animate = false;
    public float speed = 5f;
    

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
    public int capPointCount = 5;
    [Range(0, 1)] public float startSlice = 0;
    [Range(0, 1)] public float endSlice = 360;
    int startSliceIndex, endSliceIndex = 0;

    //Private Variables
    public struct point
    {
        public Vector3 position;
        public int index;
        public float theta;
    }

    List<point> points = new List<point>();
    List<Vector2> circlePositions2D = new List<Vector2>();
    List<Vector3> circlePositions = new List<Vector3>();
    
    



    float deltaTheta()
    {
        return (2 * Mathf.PI) / pointCount;
    }


    void circleLoad()
    {

        float thetaDiff = startSlice * 360 * Mathf.Deg2Rad - deltaTheta() * startSliceIndex;
        float theta = 0;
        for (int i = 0; i < pointCount; i++)
        {
            
            point P;
            P.index = i;
            P.theta = theta;
            if(i != startSliceIndex)
                P.position = new Vector3(radius * Mathf.Cos(theta + offset * Mathf.Deg2Rad), 
                                        radius * Mathf.Sin(theta + offset * Mathf.Deg2Rad),
                                        0);
            else
                P.position = new Vector3(radius * Mathf.Cos(theta + thetaDiff +  offset * Mathf.Deg2Rad),
                                        radius * Mathf.Sin(theta + thetaDiff +  offset * Mathf.Deg2Rad),
                                        0);


            if ((i >= startSliceIndex) && (i <= endSliceIndex))
            {
                circlePositions.Add(P.position);
                circlePositions2D.Add( (Vector2)P.position );
            }
            

            points.Add(P);
            theta += deltaTheta();
        }

        
        

    }


    

    void drawCircle()
    {

        

        startSliceIndex = Mathf.RoundToInt(startSlice * 360 * Mathf.Deg2Rad / deltaTheta());
        endSliceIndex = pointCount - Mathf.RoundToInt(endSlice * 360 * Mathf.Deg2Rad / deltaTheta());

        

        
        if (startSliceIndex < endSliceIndex)
        {
            line.enabled = true;
            col.enabled = true;


            points.Clear();
            circlePositions.Clear();
            circlePositions2D.Clear();

            if ((startSliceIndex != 0) || (endSliceIndex != pointCount))
                line.loop = false;
            else
                line.loop = loop;




            circleLoad();
             if (endSlice != 0)
            {
                circlePositions.Add(circlePositions[circlePositions.Count - 1]);
                circlePositions2D.Add(circlePositions2D[circlePositions2D.Count - 1]);
            }
            else 
            {
                circlePositions.Add( points[0].position );
                circlePositions2D.Add( (Vector2) points[0].position );
            }


            /*
            if (line.loop)
                circlePositions.Add(circlePositions[0]);
            */



            line.startWidth = line.endWidth = lineWidth;
            line.numCapVertices = capPointCount;
            line.positionCount = circlePositions.Count;
            line.SetPositions(circlePositions.ToArray());




            col.edgeRadius = lineWidth / 2;
            col.points = circlePositions2D.ToArray();
        }
        else
        {
            if ((line.enabled) || (col.enabled))
            {
                col.enabled = false;
                line.enabled = false;
                return;
            }
            else
            {
                return;
            }
            
            
        }
        


    }

    private void Start()
    {
        drawCircle();
    }

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        
        drawCircle();
    }
#endif

    private void Update()
    {
        if ((animate == true) && (Time.timeScale == 1) && (startSlice <= 1 - endSlice))
        {
            startSlice += Time.deltaTime / speed;
            drawCircle();
        }
    }

    


}
