using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Vector3 asteroid1 = new Vector3(1f,1f,1f);

	public GameObject laser;
	public AudioSource explosion;
	public Animator anim;

	bool death = false;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		explosion = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (gameObject.transform.position.x <= -12)
		{
			Destroy(gameObject);
		}

		rb2d.velocity = new Vector2 (-5f,0f);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (death == false) 
		{
			if (col.gameObject.tag == "Laser") 
			{
				death = true;
				anim.SetInteger ("State", 1);
				explosion.Play ();
				if (GameObject.Find ("Player"))
				{
					GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 1;
				}
				Destroy (col.gameObject);
				Destroy (gameObject, 1f / 3f);
			}

			if (col.gameObject.tag == "Player") 
			{
				death = true;
				anim.SetInteger ("State", 1);
				explosion.Play ();
				Destroy (gameObject, 1f / 3f);
			}
		} 
		else
		{
			if (col.gameObject.tag == "Laser") 
			{
				Destroy (col.gameObject);
			}
		}
	}

	void OnParticleCollision(GameObject other)
	{
		if (death == false) 
		{
			if(GameObject.Find("Player"))
			{
				GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 1;
			}
			death = true;
			anim.SetInteger ("State", 1);
			explosion.Play ();
			Destroy (gameObject, 1f / 3f);
		}
	}
}
