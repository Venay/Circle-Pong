using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }




    private void OnCollisionEnter2D(Collision2D col)
    {
        int D = (col.collider.tag == "+1") ? 1 : -1;
        print(D);

        Vector3 direction = rb.velocity.normalized;

        if (Vector2.Dot(direction, col.contacts[0].normal.normalized) >= .75f)
            direction = Quaternion.AngleAxis(Random.Range(2, 25) * D , Vector3.forward) * direction;
        else
            direction = Quaternion.AngleAxis(Random.Range(2, 25) * D , Vector3.forward) * col.contacts[0].normal.normalized;


        
        rb.velocity = direction * speed;
    }



}
