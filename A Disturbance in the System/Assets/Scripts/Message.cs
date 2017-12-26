using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour 
{
	public Text text1;

	int limit = 0;

	byte color = 0;
	int count = 0;

	// Use this for initialization
	void Start () 
	{
		text1.color = new Color32(255,255,255, 0);
		text1.text = "Good Job!";
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (count >= 60 && count <= 300 && limit == 0) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color < 255) 
			{
				color += 3;
			}
		}

		if (count >= 300 && limit == 0) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color > 3) 
			{
				color -= 3;
			} 
			else 
			{
				color = 0;
				limit = 1;
				count = 0;
				text1.text = "This was supposed to be an emotional crashing scene.";
			}
		}


		if (count >= 60 && count <= 300 && limit == 1)
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color < 255) 
			{
				color += 3;
			}
		}

		if (count >= 300 && limit == 1) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color > 3) 
			{
				color -= 3;
			} 
			else 
			{
				color = 0;
				limit = 2;
				count = 0;
				text1.text = "But I ran out of time.";
			}
		}


		if (count >= 60 && count <= 300 && limit == 2)
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color < 255) 
			{
				color += 3;
			}
		}

		if (count >= 300 && limit == 2) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color > 3) 
			{
				color -= 3;
			} 
			else 
			{
				color = 0;
				limit = 3;
				count = 0;
				text1.text = "So pretend the spaceship is landing.";
			}
		}


		if (count >= 60 && count <= 300 && limit == 3)
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color < 255) 
			{
				color += 3;
			}
		}

		if (count >= 300 && limit == 3) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color > 3) 
			{
				color -= 3;
			} 
			else 
			{
				color = 0;
				limit = 4;
				count = 0;
				text1.text = "Good Job!";
			}
		}

		if (count >= 60 && count <= 200 && limit == 4)
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color < 255) 
			{
				color += 3;
			}
		}

		if (count >= 200 && limit == 4) 
		{
			text1.color = new Color32 (255, 255, 255, color);
			if (color > 3) 
			{
				color -= 3;
			} 
			else 
			{
				color = 0;
				limit = 5;
				count = 0;
			}
		}

		count += 1;
	}
}
