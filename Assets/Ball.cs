using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ball : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
	[SerializeField]
    public static float speed = 2;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }




    private void OnCollisionEnter2D(Collision2D col)
    {

		GameEventSystem.current.ballHit();




        Vector3 direction = rb.velocity.normalized;
        int D = (col.collider.tag == "+1") ? 1 : -1;
		int rando = Random.Range(10, 30);
	
		if (Vector2.Dot(direction, col.contacts[0].normal.normalized) >= .75f)
            direction = Quaternion.AngleAxis(rando * D , Vector3.forward) * direction;
        else
            direction = Quaternion.AngleAxis(rando * D , Vector3.forward) * col.contacts[0].normal.normalized;

		rb.velocity = direction * speed;

    }



}
