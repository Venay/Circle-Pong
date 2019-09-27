using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("statics")]
	public static int score;
	public static int hightScore;
    [SerializeField] Rigidbody2D playerRB;
	[SerializeField] int circlesCount = 1;
    [SerializeField] circle[] circles;

   







	

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
            
            Debug.DrawLine(Vector2.zero, randomCirclePos(), Color.cyan, 2);

		}
	}



    Vector2 randomCirclePos()
    {
        Vector3 V = circles[Random.Range(0, circles.Length)].circleIdentifier();
        float theta = Random.Range(V.y, V.z);
        return new Vector2(V.x * Mathf.Cos(theta), V.x * Mathf.Sin(theta));
    }



    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerRB.position = Vector2.zero;
            
        }
            
    }




}
