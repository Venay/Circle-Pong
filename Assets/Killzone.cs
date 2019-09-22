using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Killzone : MonoBehaviour
{
	public Camera cam;
	public AudioSource deathSound;
	public static Color spriteColors;
	public Material spriteMaterial;
	public TextMeshProUGUI textIT;
	public TextMeshProUGUI texthightScore;
	public Color[] colors = new Color[2];


	private void Awake()
	{
		randomColors();
	}

	private void OnTriggerExit2D(Collider2D collision)
    {
		//Debug.Log("dead");
		deathSound.Play();
		pong.score = 0;
        SceneManager.LoadScene("game");
		



	}

	public void randomColors ()
	{

		int colorIndex = Random.Range(0, colors.Length - 2);
		if (colorIndex % 2 != 0)
			colorIndex++;

		if (Random.value <= 0)
		{
			cam.backgroundColor = colors[colorIndex];
			spriteColors = colors[colorIndex + 1];
			spriteColors.a = 1;
		}
		else
		{
			cam.backgroundColor = colors[colorIndex + 1];
			spriteColors = colors[colorIndex];
			spriteColors.a = 1;
		}

		spriteMaterial.color = texthightScore.color = spriteColors;
		
		spriteColors.a = .5f;
		textIT.color = spriteColors;
	}



}
