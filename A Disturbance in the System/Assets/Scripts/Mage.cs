using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour {

	private Rigidbody2D rb2d;
	float count = 0;

	public byte intensity;

	public SpriteRenderer change;

	public PlayerController user;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		change = GetComponent<SpriteRenderer> ();
		intensity = 0;
		user = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{	
		change.color = new Color32(intensity,intensity,intensity,255);

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
	}
}
