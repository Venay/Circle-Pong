using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pong : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(-transform.up * speed);
        //rb.velocity = -transform.up*speed;
    }



    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        onPlay_UI.scoreText.SetText(score.ToString());
    }
    


}
