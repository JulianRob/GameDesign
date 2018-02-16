using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed = 5f;
	public float rotateSpeed = 200f;
	private Transform target;
	private Transform target2;
	public int reflected = 0;
	public int power = 1;


	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		target = GameObject.Find ("Player").GetComponent<PlayerController> ().transform;
		target2 = GameObject.Find ("enemy2(Clone)").GetComponent <Enemy2Movement> ().transform;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (GameObject.Find ("Player"))
		{
			if (reflected == 0) 
			{
				Vector2 direction = (Vector2)target.position - rb2d.position;

				direction.Normalize ();

				float rotateAmount = Vector3.Cross (direction, transform.up).z;

				rb2d.angularVelocity = -rotateAmount * rotateSpeed;

				rb2d.velocity = transform.up * speed;
			} 
			else
			{	
				Vector2 direction = (Vector2)target2.position - rb2d.position;

				direction.Normalize ();

				float rotateAmount = Vector3.Cross (direction, transform.up).z;

				rb2d.angularVelocity = -rotateAmount * rotateSpeed;

				rb2d.velocity = transform.up * speed;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Shine")
		{
			reflected = 1;
			transform.Rotate(0,0,180);
			speed += 5;
			power += 1;
			rotateSpeed += 175;
		}

		if (col.gameObject.tag == "enemy2" && reflected == 1)
		{
			if (power >= 4) 
			{
				if (GameObject.Find("Player"))
				{
					GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber += 25;
				}
				Destroy (col.gameObject);
				Destroy(gameObject);
			}
			reflected = 0;
			transform.Rotate(0,0,180);
			rotateSpeed += 175;
			speed += 5;
			power += 1;
		}
	}
}