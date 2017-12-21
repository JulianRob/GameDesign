using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate3 : MonoBehaviour {

	private Rigidbody2D rb2d;
	int count = 0;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (gameObject.transform.position.y <= 20)
		{
			if (count >= 600) //1800
			{
				rb2d.velocity = new Vector2 (0f, 5f);
			}
			count += 1;
		} 
		else 
		{
			rb2d.velocity = new Vector2 (0f, 0f);
		}
	}
}
