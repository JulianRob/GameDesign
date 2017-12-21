using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int hp = 100;
	public Slider slider;
	public AudioSource hit;
	public GameObject winner;

	public byte color = 255;

	public SpriteRenderer change;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		change = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		slider.value = hp;
		if (hp <= 0)
		{
			winner.SetActive (true);
			slider.gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Laser") 
		{
			hit.Play ();
		}
	}

	void OnParticleCollision(GameObject other)
	{
		hp -= 1;
	}
}
