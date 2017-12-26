using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour {

	private Rigidbody2D rb2d;

	public AudioClip otherClip;
	public AudioSource audioSource;

	public bool finished = false;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (audioSource.isPlaying)
		{
			rb2d.velocity = new Vector2 (0f, -.065f);
		} 
		else 
		{
			rb2d.velocity = new Vector2 (0f,0f);
			finished = true;
		}

	}
}