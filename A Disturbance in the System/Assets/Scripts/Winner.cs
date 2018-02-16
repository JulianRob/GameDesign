using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;

	public void LoadLevel(string name)
	{
		StartCoroutine (LoadAsynchronously (name));
		Time.timeScale = 1;
		if(GameObject.Find("Player"))
			{
			GameObject.Find ("Player").GetComponent<PlayerController>().scoreNumber = 0;
			}
		loadingScreen.SetActive (true);
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

	public void MenuQuitButton()
	{
		Application.Quit ();
	}
}
