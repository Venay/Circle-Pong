using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro

public class pong : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public static int score = 0;
	public AudioSource hitAudio;

	[Header("cosmetics")]
	public SpriteRenderer sr;
	public TrailRenderer tr;

	
	public static int highScore;

	void Start()
    {
		//PlayerPrefs.DeleteAll();
        rb.velocity = (-transform.up * speed);
		highScore = PlayerPrefs.GetInt("HightScore", 0);
		onPlay_UI.hightScore.SetText(highScore.ToString());
	}



    
    private void OnCollisionEnter2D(Collision2D col)
    {
		

        score++;
		if(score > highScore)
		{
			highScore = score;
			PlayerPrefs.SetInt("HightScore", highScore);
			onPlay_UI.hightScore.SetText(highScore.ToString());

		}
		
		Vector3  direction = rb.velocity.normalized;
		if (Vector2.Dot(direction, col.contacts[0].normal.normalized) >= .85f)
			direction = Quaternion.AngleAxis(Random.Range(2, 15) * CirclePong_Controller.direc, Vector3.forward) * direction;
		else
			direction = Quaternion.AngleAxis(Random.Range(2, 15) * CirclePong_Controller.direc, Vector3.forward) * col.contacts[0].normal.normalized;


		speed += .05f;
		rb.velocity = direction * speed;
		

        onPlay_UI.scoreText.SetText(score.ToString());
		
		hitAudio.Play();
		

    }
    


}
