using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	KeyCode exit = KeyCode.Escape;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip ambient;

	void Start(){
		audioSource.clip = ambient;
		audioSource.loop = true;
		audioSource.Play();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(exit)){
			Application.Quit();
		}
	}
}
