using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour {

		public GameObject loadingScreen;
		public Slider slider;
		public string level;

	int x = 0;
	int points = 0;

	void Start()
	{
		if(GameObject.Find("Save"))
			{
				points = GameObject.Find ("Save").GetComponent<Save> ().score;
			}
	}

	void Update()
	{
		if (GameObject.Find ("Player"))
		{
			if (GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber - points >= 75 && level == "Scene2") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}

			if (GameObject.Find ("Bird") == false && level == "Scene3") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}

			if (GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber - points >= 150 && level == "Scene4") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}

			if (GameObject.Find ("Mage") == false && level == "Credits") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}
		}

		if (GameObject.Find ("User") == true && GameObject.Find("User").GetComponent<falling>().finished == true && level == "Winner") 
		{
			if (x == 0) 
			{
				loadingScreen.SetActive (true);
				LoadLevel (level);
				x += 1;
			}
		}
	}

		public void LoadLevel(string name)
		{
			StartCoroutine (LoadAsynchronously (name));
		}

		IEnumerator LoadAsynchronously (string name)
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync (name);

			while (!operation.isDone) 
			{
				float progress = Mathf.Clamp01 (operation.progress / .9f);

				slider.value = progress;

				yield return null;
			}
		}
	
}
