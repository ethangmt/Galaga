using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

	public static soundManager instance = null;
	private AudioSource soundEffects = null;

	public AudioClip fire = null;

	// Use this for initialization
	void Start () {

		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (this); 
		}

		soundEffects = GetComponent<AudioSource> (); 
	}

	public void PlayOneShot (AudioClip clip) {
		soundEffects.PlayOneShot (clip); 
	}
}
