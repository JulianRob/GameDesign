using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {

	private Rigidbody2D rb2d;
	float count = 0f;
	public AudioSource shoot;
	public GameObject laser;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb2d.velocity = new Vector2 (0f, Mathf.Sin(count));
		count += .1f;

		if (!GameObject.Find ("HomingMissile2(Clone)")) 
		{
			Instantiate (laser, gameObject.transform.position,Quaternion.identity);
			shoot.Play ();
		}
	}
}
