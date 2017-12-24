using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb2d.velocity = new Vector2 (15f,0f);

		if (gameObject.transform.position.x >= 12)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Destroy (gameObject);
		}

		if (col.gameObject.tag == "boss") 
		{
			GameObject.Find ("Bird").GetComponent<Bird> ().hp -= 1;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (GameObject.Find("Player"))
		{
			GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 1;
		}
		Destroy (gameObject);
	}
}
