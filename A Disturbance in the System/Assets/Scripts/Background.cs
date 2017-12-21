using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float speed;
	Vector3 startPOS;

	// Use this for initialization
	void Start () 
	{
		startPOS = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate ((new Vector3 (-1, 0, 0)) * speed * Time.deltaTime);
		if (transform.position.x < -24.94)
		{
			transform.position = startPOS;
		}
	}
}
