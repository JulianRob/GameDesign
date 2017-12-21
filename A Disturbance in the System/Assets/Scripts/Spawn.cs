using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	public GameObject asteroid;
	public GameObject laser;
	public GameObject powerUp;

	public AudioSource fireBreath;
	int once = 0;

	public Bird boss;
	public PlayerController user;

	public GameObject Particle;
	public ParticleSystem part;

	int count = 0;
	int count2;
	int count4 = 0;
	float Timer = 0.0f;

	int limit = 0;

	void Start()
	{
		user = GameObject.Find ("Player").GetComponent<PlayerController> ();
		boss = GameObject.Find ("Bird").GetComponent<Bird> ();
		Physics2D.IgnoreLayerCollision(9,13,true);
	}

	void Update () 
	{
		if (GameObject.Find ("Player") && GameObject.Find("Bird")) 
		{
			if (limit == 0 && user.count3 >= 150)
			{
				boss.rb2d.velocity = new Vector2 (-3f, 0f);

				if (count2 <= 0) 
				{
					Instantiate(asteroid,new Vector3(12f,Random.Range(-5f,5f),0f),gameObject.transform.rotation);
					count2 = 60;
				}

				if (boss.transform.position.x <= 6f)
				{
					Physics2D.IgnoreLayerCollision(9,13,false);
					boss.rb2d.velocity = new Vector2 (0f, 0f);
				}

				boss.transform.position = new Vector2(boss.transform.position.x,0f);
				count2 -= 1;

				if (boss.hp <= 50) 
				{
					limit = 1;
					Physics2D.IgnoreLayerCollision(9,13,true);
				}

				if (boss.hp <= 75 && Timer <= 4.5) //180
				{
					boss.change.color = new Color32(255,boss.color,boss.color, 255);
					if (boss.color > 1)
					{
						boss.color -= 2;
					}

					if (boss.color <=1) 
					{
						boss.color = 0;
						if (once == 0) 
						{
							once = 1;
							fireBreath.Play ();
						}

						Particle.SetActive (true);
						Timer += Time.deltaTime;
					}
				} 
				else 
				{
					//Particle.SetActive (false);
					part.Stop();
					boss.change.color = new Color32(255,255,255, 255);
				}
			}

			if (limit == 1) 
			{
				//Particle.SetActive (false);
				part.Stop();
				boss.change.color = new Color32(255,255,255, 255);

				boss.rb2d.velocity = new Vector2 (3f, 0f);
				if (boss.transform.position.x >= 12) 
				{
					boss.rb2d.velocity = new Vector2 (0f, 0f);
				}

				if (count4 <= 0) 
				{
					Instantiate(enemy,new Vector3(6f,5f,0f),gameObject.transform.rotation);
					Instantiate(enemy,new Vector3(6f,3f,0f),gameObject.transform.rotation);
					Instantiate(enemy,new Vector3(6f,1f,0f),gameObject.transform.rotation);
					Instantiate(enemy,new Vector3(6f,-1f,0f),gameObject.transform.rotation);
					Instantiate(enemy,new Vector3(6f,-3f,0f),gameObject.transform.rotation);
					Instantiate(enemy,new Vector3(6f,-5f,0f),gameObject.transform.rotation);
					count4 += 1;
				}

				if (!GameObject.Find ("Enemy(Clone)"))
				{
					limit = 2;
				}
			}

			if (limit == 2) 
			{
				boss.rb2d.velocity = new Vector2 (-3f, 0f);
				if (count == 0) 
				{
					Instantiate(powerUp,new Vector3(12f,-4f,0f),gameObject.transform.rotation);
					count += 1;
				}
				if (boss.transform.position.x <= 6f)
				{
					Physics2D.IgnoreLayerCollision(9,13,false);
					boss.rb2d.velocity = new Vector2 (0f, 0f);
				}
				boss.transform.position = new Vector2(boss.transform.position.x,0f);
			}
		}
	}
}