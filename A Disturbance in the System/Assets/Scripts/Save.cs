using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour 
{
	public int score = 0;
	
	void Update()
	{
		if (GameObject.Find ("Player")) 
		{
			score = GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber;
		} 
		else 
		{
			score = 0;
		}
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

}
