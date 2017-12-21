using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	
	// Update is called once per frame. Used for rotation
	void Update () 
	{
		transform.Rotate (0f, 0f, -5f);
	}
}
