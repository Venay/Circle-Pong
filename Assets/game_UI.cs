using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class game_UI : MonoBehaviour
{
	public Text T;

	private void Update()
	{
		T.text = GameManager.score.ToString();
	}

	public void LoadStartGame()
	{
		SceneManager.LoadScene("start");
	}



}
