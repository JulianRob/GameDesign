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

	void Update()
	{
		if (GameObject.Find ("Player"))
		{
			if (GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber >= 75 && level == "Scene2") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}

			if (GameObject.Find ("Bird") != true && level == "Scene3") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
			}

			if (GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber >= 150 && level == "Scene4") 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel (level);
					x += 1;
				}
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
