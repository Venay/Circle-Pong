using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;




public class circlePong : MonoBehaviour
{
    [Header("circle Setting")]
    public int vertexCount = 32;
    public int startingRemovedVount = 5;
    public float radius = 3f;
    public float rotation = 0;
    public float lineWidth = .1f;

    public LineRenderer line;
    public EdgeCollider2D col;


    [Header("Gameplay setting")]
    public bool isShrinking = true;
    //public float rotationSpeed = 10f;
    public float removeEvery = 1f;
    public int minimumVerts = 15;

    List<Vector2> edgeVerts = new List<Vector2>();

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        setupCircle();
        if(isShrinking)
            StartCoroutine(shrinkLine());

    }

    


    void setupCircle()
    {
        edgeVerts.Clear();
        
        line.widthMultiplier =  lineWidth;
        col.edgeRadius = lineWidth / 2;
        line.positionCount = vertexCount - startingRemovedVount;

        float rot = rotation * Mathf.Deg2Rad;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        

        for (int i = 0; i < vertexCount - startingRemovedVount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta + rot), radius * Mathf.Sin(theta + rot), 0);
            edgeVerts.Add(pos);
            col.points = edgeVerts.ToArray();
            line.SetPosition(i, pos);

            theta += deltaTheta;
        }

        if (!isShrinking)
            if ((vertexCount - startingRemovedVount) == vertexCount)
            {
                line.loop = true;
                edgeVerts.Add(edgeVerts[0]);
                col.points = edgeVerts.ToArray();
            }
        
        




    }

    IEnumerator shrinkLine()
    {
        while(vertexCount > minimumVerts)
        {
            startingRemovedVount++;
            setupCircle();
            yield return new WaitForSeconds(removeEvery);
        }
    }



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //vertexCount = Mathf.RoundToInt( Mathf.Clamp(vertexCount, 3, Mathf.Infinity));
        float rot = rotation * Mathf.Deg2Rad;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;

        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta + rot), radius * Mathf.Sin(theta + rot), 0);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }
    }
#endif



}
