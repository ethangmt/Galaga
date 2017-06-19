using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float bulletSpeed = 100;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * bulletSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		// Walls
		string name = col.gameObject.tag;
		if (name == "wall") {
			Destroy (gameObject); 
		}

		if (name == "enemy") {
			col.gameObject.GetComponent<Animator> ().SetBool ("dead", true);
			soundManager.instance.PlayOneShot (soundManager.instance.explosionEnemy);
			Destroy (gameObject);
		}
	}
}
