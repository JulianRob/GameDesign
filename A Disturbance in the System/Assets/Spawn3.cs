using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn3 : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemy2;
	public GameObject asteroid;
	public PlayerController user;

	int count2;
	int count4;

	float Timer = 0.0f;

	void Start()
	{
		user = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	void Update () 
	{
		if (GameObject.Find ("Player")) 
		{
			if (!GameObject.Find ("Enemy(Clone)") && user.count3 >= 150) 
			{
				Instantiate (enemy, new Vector3 (6f, Random.Range(-5f,5f),0f), enemy.transform.rotation);
			}
				
			if (!GameObject.Find ("enemy2(Clone)") && user.count3 >= 150) 
			{
				Instantiate (enemy2, new Vector3 (8.5f,0,0f), enemy.transform.rotation);
			}

			if (count2 <= 0 && user.count3 >= 150 && Timer >= 1) 
			{
				Instantiate(asteroid,new Vector3(12f,Random.Range(-5f,5f),0f),gameObject.transform.rotation);
				Timer = 0;
				count2 = 60;
			}
		}
		Timer += Time.deltaTime;
		count2 -= 1;
	}
}