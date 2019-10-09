using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class game_UI : MonoBehaviour
{
	public Text T;
	public Image toggleImage;
	public Sprite radialIcon,horizontalIcon,verticalIcon;


	private void Start()
	{
		switch (GameManager.control)
		{
			case (GameManager.contolStyle.radial):
				{
					toggleImage.sprite = radialIcon;
					break;
				}
			case (GameManager.contolStyle.horizontal):
				{
					toggleImage.sprite = horizontalIcon;
					break;
				}
			case (GameManager.contolStyle.vertical):
			{
					toggleImage.sprite = verticalIcon;
				break;
			}
			default:break;
		}
	}


	private void Update()
	{
		T.text = GameManager.score.ToString();
	}

	public void LoadStartGame()
	{
		SceneManager.LoadScene("start");
	}

	public void toggleControlType()
	{
		switch (GameManager.control)
		{

			case (GameManager.contolStyle.radial):
				{
					toggleImage.sprite = horizontalIcon;
					GameManager.control = GameManager.contolStyle.horizontal;
					break;
				}
			case (GameManager.contolStyle.horizontal):
				{
					toggleImage.sprite = verticalIcon;
					GameManager.control = GameManager.contolStyle.vertical;
					break;
				}
			case (GameManager.contolStyle.vertical):
				{
					toggleImage.sprite = radialIcon;
					GameManager.control = GameManager.contolStyle.radial;
					break;
				}

			default: break;
		}

	}

}
