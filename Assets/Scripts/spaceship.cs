using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour {

	public float speed = 30;
	public GameObject bulletPrefab;
	public float fireRate = 0.5F;
	public float nextFire = 0.2F;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move ();

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			// Create bullet instance
			fire();
		}
	}

	void fire () {
		nextFire = Time.time + fireRate;
		float x = GetComponent<Transform> ().position.x;
		float y = GetComponent<Transform> ().position.y;
		Instantiate (bulletPrefab, new Vector2 (x, y + 8), Quaternion.identity);
		soundManager.instance.PlayOneShot (soundManager.instance.fire);
	}

	void move () {
		float hMove = Input.GetAxisRaw ("Horizontal");
		float vMove = Input.GetAxisRaw ("Vertical"); 
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (hMove, vMove) * speed;
	}
}
