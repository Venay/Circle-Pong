using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("statics")]
	public static int score;
	public static int hightScore;
	public static int scoreMultiplyer;
	public static bool isInsideCrit;
	public static GameObject critOBJ;
	[SerializeField] Rigidbody2D playerRB;
	[SerializeField] int circlesCount = 1;
	[SerializeField] circle[] circles;

	[Header("Ciritcal Object")]
	[SerializeField] Camera cam;
	[SerializeField] GameObject criticalObjectPrefab;
	[SerializeField] float spawnDelay = 1f;
	public static int criticalObjectCount = 0;
	GameObject criticalObject;

	[Space]
	[SerializeField] Color critHitColor ;
	Color oldCamColor ;
	[SerializeField] int frames;

	public enum contolStyle { radial, horizontal , vertical }
	[Header("Control")]
	[SerializeField]public static contolStyle control = contolStyle.radial;
	public contolStyle controlType = contolStyle.radial;

	private void Start()
	{	
		GameEventSystem.current.onBallHit += ballHit;
		oldCamColor = cam.backgroundColor;
		spawnCritical();
		control = controlType;

	}



	





	void ballHit()
	{
		if (isInsideCrit)
		{
			//score
			scoreMultiplyer++;
			score += 2 * scoreMultiplyer;

			//effects
			StartCoroutine(lerpValue(critHitColor, frames));
			cam.backgroundColor = Color.Lerp(oldCamColor, critHitColor, Mathf.Clamp01(scoreMultiplyer / 10.0f));


			//Ball
			Ball.speed += .1f ;

			//Crit Object
			Destroy(critOBJ);
			criticalObjectCount--;
			isInsideCrit = false;
			spawnCritical();

		}
		else
		{
			score++;
			scoreMultiplyer = 1;
			Ball.speed = 2;
		}
		

		
	}

	IEnumerator lerpValue(Color toC, int frames)
	{
		Color defaultC = cam.backgroundColor;
		for (int i = 0; i <= frames; i++)
		{

			cam.backgroundColor = Color.Lerp(toC, defaultC, (float)i / frames );
			yield return null;

		}


	}

	public void spawnCritical()
	{
		StartCoroutine(spawnCritical(spawnDelay));
	}

	

	



	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			StartCoroutine(lerpValue(Color.red, 15));
			score = 0;
			scoreMultiplyer = 1;
			playerRB.position = Vector2.zero;

		}

	}





	IEnumerator spawnCritical( float delay)
	{
		criticalObjectCount++;
		yield return new WaitForSeconds(delay);
		int i = Random.Range(0, circles.Length);
		Vector2 pos = circles[i].colPos[Random.Range(0, circles[i].colPos.Length)];
		pos = circles[i].transform.rotation * pos;
		critOBJ = Instantiate(criticalObjectPrefab, pos, Quaternion.identity, circles[i].transform);
	}


	static public float getAngle2D(Vector2 V1, Vector2 V2)
	{
		return Mathf.Acos(Vector2.Dot(V1, V2) / (V1.magnitude * V2.magnitude)) * Mathf.Rad2Deg;
	}


	public static float getAngle2D(Vector2 V1, Vector2 V2)
	{
		return Mathf.Acos(Vector2.Dot(V1, V2) / (V1.magnitude * V2.magnitude)) * Mathf.Rad2Deg;
	}


}
