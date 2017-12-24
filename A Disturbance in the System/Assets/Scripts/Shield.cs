using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	private ParticleSystem ps;
	bool hit = false;
	int count = 0;
	int health = 30;
	public AudioSource explosion;
	public AudioSource BarrierBreak;
	float color = 1;

	void Start () 
	{
		ps = GetComponent<ParticleSystem>();
		var main = ps.colorOverLifetime;
		//main.startColor = new Color(color,color,color,color);
		//main.color = new Color(255,245,103,255);
	}

	void FixedUpdate()
	{
		var main = ps.colorOverLifetime;

		if (hit == true && health > 0) 
		{
			main.color = new Color (255f, 0f, 0f, 255f); //red
			count += 1;
			if (count >= 3)
			{
				hit = false;
				main.color = new Color (255f, 245f, 103f, 255f); //yellow
				count = 0;
			}
		}

		if (health <= 0) 
		{
			main.color = new Color (color, 0f, 0f, color); //red
			color -= .01f;
			if (color <= 0) 
			{
				color = 0;
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Laser" && health > 0) 
		{
			hit = true;
			var main = ps.colorOverLifetime;
			main.color = new Color (255f, 0f, 0f, 255f);
			health -= 1;
			if (health <= 0) 
			{
				health = 0;
				BarrierBreak.Play ();
			} 
			else
			{
				explosion.Play ();
			}
		}
	}
}
