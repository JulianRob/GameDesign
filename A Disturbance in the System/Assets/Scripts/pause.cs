using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

	public GameObject Quit;
	public GameObject Restart;
	public GameObject text;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				Quit.SetActive (true);
				Restart.SetActive (true);
				text.SetActive (true);
			} 
			else 
			{
				Time.timeScale = 1;
				Quit.SetActive (false);
				Restart.SetActive (false);
				text.SetActive (false);
			}
		}
	}
}
