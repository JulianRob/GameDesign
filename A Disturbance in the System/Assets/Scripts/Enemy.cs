using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject laser;
	private Rigidbody2D rb2d;
	int count = 0;
	float vertical;
	public Animator anim;

	int health = 5;

	public AudioSource hit;
	public AudioSource hit2;
	public AudioSource shoot;

	bool death = false;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0f, -5f);
		vertical = rb2d.velocity.y;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame

	void Update()
	{
		if (death == false) 
		{
			transform.position = new Vector3(6.0f,transform.position.y,transform.position.z);
		}
	}

	void FixedUpdate () 
	{
		if (count <= 0) 
		{
			if (death == false) 
			{
				Instantiate (laser, gameObject.transform.position, gameObject.transform.rotation);
				shoot.Play ();
				count = 60;
			}
		}
		count -= 1;

		if (death == false) {
			if (gameObject.transform.position.y >= 5) {
				rb2d.velocity = new Vector2 (0f, -5f);
				vertical = rb2d.velocity.y;
			} else if (gameObject.transform.position.y <= -5) {
				rb2d.velocity = new Vector2 (0f, 5f);
				vertical = rb2d.velocity.y;
			}
		}

		rb2d.velocity = new Vector2 (0f, vertical);

		if (death == true) 
		{
			rb2d.velocity = new Vector2 (-3f, vertical);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (death == false) 
		{
			if (col.gameObject.tag == "Laser") 
			{
				health -= 1;
				hit.Play ();
				if (health <= 0) 
				{
					death = true;
					if (GameObject.Find ("Player")) 
					{
						GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 5;
					}
					hit2.Play ();
					anim.SetInteger ("State", 1);
					Destroy (gameObject, 5f / 6f);
				}
			}
		}
	}

	void OnParticleCollision(GameObject other)
	{
		if (death == false) 
		{
			if (GameObject.Find ("Player")) 
			{
				GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 50;
			}
			death = true;
			anim.SetInteger ("State", 1);
			hit.Play ();
			Destroy (gameObject, 5f / 6f);
		}
	}
}
