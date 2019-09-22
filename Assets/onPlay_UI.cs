
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System;


public class onPlay_UI : MonoBehaviour
{

	public static TextMeshProUGUI scoreText;
	public TextMeshProUGUI textElement;
	public static TextMeshProUGUI hightScore;
	public TextMeshProUGUI hightScoreClone;

	





	private void Awake()
    {
		

        scoreText = textElement;
		hightScore = hightScoreClone;



		Time.timeScale = 0;
    }

  

    public void pressToStart()
    {
        
        Time.timeScale = 1;
        
    } 

    

    public void updateSore()
    {
        scoreText.SetText("0");
    }
    


}
