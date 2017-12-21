using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour {

		public GameObject loadingScreen;
		public Slider slider;

	int x = 0;

	void Update()
	{
		if (GameObject.Find ("Player"))
		{
			if (GameObject.Find ("Player").GetComponent<PlayerController> ().scoreNumber >= 75) 
			{
				if (x == 0) 
				{
					loadingScreen.SetActive (true);
					LoadLevel ("Scene2");
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
