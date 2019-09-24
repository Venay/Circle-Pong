using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Draw_Circle : MonoBehaviour
{
    [Header("Component Setup")]
    public LineRenderer line;
    public EdgeCollider2D col;

    [Header("Circle Settings")]
    public float radius = 1;
    public int pointCount = 100;
    public struct point
    {
        public int index;
        public Vector3 position;
    }

    public float T()
    {
        return Time.deltaTime;
    }
   

    private void OnValidate()
    {
        Debug.Log(T());
    }

}



