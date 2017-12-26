using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Transform target;
	bool look = false;

	int count = 0;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		target = GameObject.Find ("Player").GetComponent<PlayerController> ().transform;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		count += 1;
		if (count >= 240) 
		{
			
			if (look == false)
			{
				transform.LookAt(target);
				look = true;
			}
			rb2d.AddForce(transform.forward*50);

			/*
			if (GameObject.Find ("Player").GetComponent<PlayerController> ().transform.position.y <= transform.position.y) 
			{
				rb2d.AddForce (-transform.up * 20);
				//rb2d.velocity = new Vector2(rb2d.velocity.x,-7f);
			} 
			else 
			{
				rb2d.AddForce (transform.up * 20);
				//rb2d.velocity = new Vector2(rb2d.velocity.x,7f);
			}
			*/
		}

		if (transform.position.x <= -10 || transform.position.x >= 10 || transform.position.y >= 7 || transform.position.y <= -7) 
		{
			Destroy (gameObject);
		}
	}
}
