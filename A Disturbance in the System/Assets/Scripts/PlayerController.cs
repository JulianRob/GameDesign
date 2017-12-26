using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	// ----------------------------------------------
	public float speed;

	private Rigidbody2D rb2d;
	private Rigidbody2D halt;
	public Animator anim;

	public AudioSource shoot;
	public AudioSource hit;

	public GameObject asteroid;
	public GameObject restart;
	public GameObject enemy;

	public GameObject instruction;

	public GameObject Particle;
	public GameObject Shine;
	public AudioSource ShineSound;

	public int count;
	public int count2;
	public int count3; //Duration for displaying the objective. 
	int count4;

	bool reflect = false;


	int maxSpeed = 10;

	public GameObject laser;

	public int healthNumber;
	public Text healthText;

	public int scoreNumber;
	public Text scoreText;

	public GameObject objective;

	bool death2 = false;

	bool power = false; //Big particle explosion by pressing J

	public Slider slider;
	float mana = 50f;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		shoot = GetComponent<AudioSource>();
		healthNumber = 100;
		if (GameObject.Find ("Save")) 
		{
			scoreNumber = GameObject.Find ("Save").GetComponent<Save> ().score;
		}
		count = 0;
		Physics2D.IgnoreLayerCollision(8,10,false);
		//Physics2D.IgnoreLayerCollision(8,15,false);
	} 
		
	void FixedUpdate()
	{

		// Variables to store user input from keyboard
		float moveHorizontal = Input.GetAxis ("Horizontal"); //Move to the right.
		float moveVertical = Input.GetAxis ("Vertical"); //Move to the left. 

		if (moveHorizontal > 0) 
		{
			moveHorizontal = 1;
		}

		if (moveHorizontal < 0) 
		{
			moveHorizontal = -1;
		}

		if (moveVertical > 0)
		{
			moveVertical = 1;
		}

		if (moveVertical < 0) 
		{
			moveVertical = -1;
		}

		//MAKES THE PLAYER STOP MOVING WHEN BUTTONS ARE PRESSED

		if (!Input.GetKey ("a") && !Input.GetKey ("d")) 
		{
			moveHorizontal = 0f;
		}

		if (!Input.GetKey ("w") && !Input.GetKey ("s")) 
		{
			moveVertical = 0f;
		}

		if (count <= 0 && death2 == false) 
		{
			if (Input.GetKey ("space")) 
			{
				Instantiate(laser,gameObject.transform.position,gameObject.transform.rotation);
				shoot.Play ();
				count = 10;
			}
		}

		if (Input.GetKey (KeyCode.J) && power == true) 
		{
			Particle.SetActive (true);
		} 
		else 
		{
			Particle.SetActive (false);
		}

		if (power == true && count2 <= 150) 
		{
			instruction.SetActive (true);
			count2 += 1;
		} 
		else
		{
			instruction.SetActive (false);
		}
	
		if (rb2d.velocity.y >= maxSpeed) 
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, maxSpeed);
		}

		if (rb2d.velocity.y <= -maxSpeed) 
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, -maxSpeed);
		}

		if (rb2d.velocity.x >= maxSpeed) 
		{
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x <= -maxSpeed) 
		{
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}

		if (death2 == false)
		{
			if (gameObject.transform.position.x <= -8.8) 
			{
				gameObject.transform.position = new Vector2 (-8.8f, gameObject.transform.position.y);
				rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			}

			if (gameObject.transform.position.x >= 8.8) 
			{
				gameObject.transform.position = new Vector2 (8.8f, gameObject.transform.position.y);
				rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			}

			if (gameObject.transform.position.y <= -5.3f) 
			{
				gameObject.transform.position = new Vector2 (gameObject.transform.position.x,-5.3f);
				rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
			}

			if (gameObject.transform.position.y >= 5.3) 
			{
				gameObject.transform.position = new Vector2 (gameObject.transform.position.x,5.3f);
				rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
			}
		}

		if (Input.GetKey (KeyCode.A) && healthNumber > 0)
		{
			anim.SetInteger ("State", 1);
		} 
		else if(healthNumber > 0)
		{
			anim.SetInteger ("State", 0);
		}

		if (count3 <= 150) //Control for objective.
		{
			count3 += 1;
		} 
		else
		{
			objective.SetActive (false);
		}

		rb2d.velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);

		if (death2 == true) 
		{
			rb2d.velocity = new Vector2 (-5f,0f);
		}

		//Gives a boost
		/*
		if (Input.GetKey (KeyCode.K) && healthNumber > 0) 
		{
			if (rb2d.velocity.x > 0 && rb2d.velocity.y > 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x+5, rb2d.velocity.y+5);
			}
			else if (rb2d.velocity.x < 0 && rb2d.velocity.y < 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x-5, rb2d.velocity.y-5);
			}
			else if (rb2d.velocity.x > 0 && rb2d.velocity.y < 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x+5, rb2d.velocity.y-5);
			}
			else if (rb2d.velocity.x < 0 && rb2d.velocity.y > 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x-5, rb2d.velocity.y+5);
			}
			else if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, rb2d.velocity.y);
			}
			else if (rb2d.velocity.x == 0 && rb2d.velocity.y > 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, rb2d.velocity.y+5);
			}
			else if (rb2d.velocity.x == 0 && rb2d.velocity.y < 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, rb2d.velocity.y-5);
			}
			else if (rb2d.velocity.x > 0 && rb2d.velocity.y == 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x+5, rb2d.velocity.y);
			}
			else if (rb2d.velocity.x < 0 && rb2d.velocity.y == 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x-5, rb2d.velocity.y);
			}
		}
		*/

		if (Input.GetKeyDown (KeyCode.K) == true && healthNumber > 0)
		{
			if (slider.value >= 10 && count4 == 0) 
			{
				mana -= 10;
				reflect = true;
			}
		}

		if (reflect == true && count4 <= 10) 
		{
			Shine.SetActive (true);
			if (count4 <= 0) 
			{
				ShineSound.Play ();
			}
			count4 += 1;
		}
		else 
		{
			Shine.SetActive (false);
			count4 = 0;
			reflect = false;
			/*
			if(count4 >= 20)
			{
				count4 += 1;
			}

			if (count4 >= 60) 
			{
				count4 = 0;
			}
			*/
		}

		if (count >= -20) 
		{
			count -= 1;
		}

		if (mana+.01 <= 50) 
		{
			mana += .02f;
		}

		healthText.text = "Health: " + healthNumber.ToString();
		scoreText.text = "Score: " + scoreNumber.ToString();
		slider.value = mana;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Asteroid")
		{
			if (healthNumber >= 10) 
			{
				healthNumber -= 10;
			}
			else 
			{
				healthNumber = 0;
			}
			if (healthNumber <= 0)
			{
				death ();
			}
		}

		if (col.gameObject.tag == "laser2") 
		{
			if (healthNumber >= 10) 
			{
				healthNumber -= 10;
			}
			else 
			{
				healthNumber = 0;
			}

			hit.Play();
			Destroy (col.gameObject);
			if (healthNumber <= 0)
			{
				death ();
			}
		}

		if (col.gameObject.tag == "powerUp") 
		{
			power = true;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "orb") 
		{
			if (healthNumber >= 10) 
			{
				healthNumber -= 10;
			}
			else 
			{
				healthNumber = 0;
			}

			hit.Play();
			Destroy (col.gameObject);
			if (healthNumber <= 0)
			{
				death ();
			}
		}
	}

	void OnParticleCollision(GameObject other)
	{
		if (other.gameObject.tag == "fire" && healthNumber > 0)
		{
			healthNumber -= 1;
			hit.Play();
		}

		if (healthNumber <= 0)
		{
			death ();
		}
	}

	void death()
	{
		death2 = true;
		Physics2D.IgnoreLayerCollision(8,17,true);
		healthText.text = "Health: " + healthNumber.ToString();
		anim.SetInteger ("State", 2);
		restart.SetActive (true);
		Physics2D.IgnoreLayerCollision(8,10,true);
		scoreNumber = 0;
		Destroy (gameObject,5f/6f);
	}
} 