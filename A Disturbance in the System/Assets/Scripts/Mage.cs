using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mage : MonoBehaviour {

	private Rigidbody2D rb2d;
	float count = 0;
	int count2 = 0;
	int count3 = 0;
	public int hp = 100;
	public Slider slider;
	public AudioSource hit;
	private Animator anim;

	public GameObject orb;

	public byte intensity;

	private SpriteRenderer change;

	private PlayerController user;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		change = GetComponent<SpriteRenderer> ();
		intensity = 0;
		user = GameObject.Find ("Player").GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{	
		change.color = new Color32(intensity,intensity,intensity,255);
		slider.value = hp;

		if (user.count3 >= 150) 
		{
			if (intensity + 5 < 255) 
			{
				intensity += 5;
			} 
			else 
			{
				intensity = 255;
			}
		}

		rb2d.velocity = new Vector2 (0f, Mathf.Sin(count));
		count += 0.1f;

		if (hp <= 0)
		{
			slider.gameObject.SetActive (false);
			Destroy (gameObject);
		}

		if (hp > 50 && GameObject.Find("Player") == true) 
		{
			if (count3 == 0) 
			{
				Instantiate(orb,new Vector3(1f,4f,0f),gameObject.transform.rotation);
			}

			if (count3 == 90) 
			{
				Instantiate(orb,new Vector3(8f,4f,0f),gameObject.transform.rotation);
			}

			if (count3 == 180) 
			{
				Instantiate(orb,new Vector3(8f,-4.5f,0f),gameObject.transform.rotation);
			}
				
			if (count3 == 270)
			{
				Instantiate(orb,new Vector3(1f,-4.5f,0f),gameObject.transform.rotation);
				count3 = -90;
			}

			count3 += 1;
		}

		if (hp <= 50 && GameObject.Find("Player") == true) 
		{
				if (count2 == 0) 
				{
					anim.SetInteger ("state", 1);
					Instantiate(orb,new Vector3(2f,3f,0f),gameObject.transform.rotation);
				}

				if (count2 == 30) 
				{
					Instantiate(orb,new Vector3(4.5f,4f,0f),gameObject.transform.rotation);
				}

				if (count2 == 60) 
				{
					Instantiate(orb,new Vector3(7f,3f,0f),gameObject.transform.rotation);
				}

				if (count2 == 90)
				{
					Instantiate(orb,new Vector3(7.5f,0f,0f),gameObject.transform.rotation);
				}

				if (count2 == 120) 
				{
					Instantiate(orb,new Vector3(7f,-4f,0f),gameObject.transform.rotation);
				}

				if (count2 == 150) 
				{
					Instantiate(orb,new Vector3(4.5f,-5f,0f),gameObject.transform.rotation);
				}

				if (count2 == 180)
				{
					Instantiate(orb,new Vector3(2f,-4f,0f),gameObject.transform.rotation);
				}

				if (count2 == 210)
				{
					Instantiate(orb,new Vector3(1.5f,0f,0f),gameObject.transform.rotation);
					count2 = -30;
				}
				count2 += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Laser") 
		{
			if(!GameObject.Find("Shield"))
				{
					hp -= 1;
					Destroy (col.gameObject);
					hit.Play ();
				}
		}
	}
}
