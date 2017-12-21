using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private Rigidbody2D rb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate ()
	{
		rb2d.velocity = new Vector2 (-5f, 0f);
	}
}
