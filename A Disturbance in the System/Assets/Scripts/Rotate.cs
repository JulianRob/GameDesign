using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	float Timer = 0.0f;

	// Update is called once per frame. Used for rotation
	void FixedUpdate () 
	{
		if (Timer >= (1/60)) 
		{
			transform.Rotate (0f, 0f, -5f);
			Timer = 0;
		}
		Timer += Time.deltaTime; //Seconds
	}
}