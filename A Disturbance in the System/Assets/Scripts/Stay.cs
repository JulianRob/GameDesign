using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour {
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
