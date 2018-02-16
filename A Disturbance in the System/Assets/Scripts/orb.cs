using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Transform target;
	bool look = false;
	int direction = 0;

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
		if (count >= 120) 
		{
			
			if (look == false)
			{
				transform.LookAt(target);
				look = true;
			}
			if (direction == 0) 
			{
				rb2d.AddForce (transform.forward * 50);
			} 
			else 
			{
				rb2d.velocity = (-transform.forward * 25);
				//rb2d.AddForce (-transform.forward * 50);
			}

		}

		if (transform.position.x <= -10 || transform.position.x >= 10 || transform.position.y >= 7 || transform.position.y <= -7) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Shine")
		{
			direction = 1;
		}
	}
}

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
