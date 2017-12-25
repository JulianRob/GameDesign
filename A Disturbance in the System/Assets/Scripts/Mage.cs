using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mage : MonoBehaviour {

	private Rigidbody2D rb2d;
	float count = 0;
	public int hp = 100;
	public Slider slider;
	public AudioSource hit;
	public Animator anim;

	public byte intensity;

	public SpriteRenderer change;

	public PlayerController user;

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

		if (hp <= 50) 
		{
			anim.SetInteger ("state", 1);
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
