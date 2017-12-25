using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private Rigidbody2D rb2d;

	int count = 0;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		count += 1;
		if (count >= 300) 
		{
			rb2d.AddForce(-transform.right * 20);
		}
	}
}
