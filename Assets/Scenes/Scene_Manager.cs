using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
	//[SerializeField] Scene[] scenes;



    
    public void loadScene1()
	{
		SceneManager.LoadScene("game 1");
	}

	public void loadScene2()
	{
		SceneManager.LoadScene("game 2");
	}

	public void loadScene3()
	{
		SceneManager.LoadScene("game 3");
	}

}
