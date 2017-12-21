using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	static SceneSwitch Instance;

	void Start()
	{
		if (Instance != null) 
		{
			GameObject.Destroy (gameObject);
		} 
		else 
		{
			GameObject.DontDestroyOnLoad (gameObject);
			Instance = this;
		}
	}

	void Update()
	{
		if (Input.GetKeyUp (KeyCode.I)) 
		{
			SceneManager.LoadScene ("Scene1", LoadSceneMode.Single);
		}

		if(Input.GetKeyUp (KeyCode.J)) 
		{
			SceneManager.LoadScene ("Scene2", LoadSceneMode.Single);
		}
	}
}
