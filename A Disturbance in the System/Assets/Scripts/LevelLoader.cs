using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public GameObject button;
	public GameObject black;
	public Slider slider;

	public GameObject duck1;
	public GameObject duck2;
	public GameObject duck3;
	public GameObject title;

	public void LoadLevel(string name)
	{
		StartCoroutine (LoadAsynchronously (name));
	}

	IEnumerator LoadAsynchronously (string name)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (name);
		button.SetActive (false);
		black.SetActive (false);
		duck1.SetActive (false);
		duck2.SetActive (false);
		duck3.SetActive (false);
		title.SetActive (false);
		
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
