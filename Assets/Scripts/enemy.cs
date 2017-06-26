using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public bool dead = false;
	public float speed = 1; //30

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	//int i = 0;
	void Update () {
		//if (i < pathManager.path1.Count) {
		//	i = path.instance.followPath (gameObject, pathManager.path1, 1, i);
		//}
	}

	public void die () {
		Destroy (gameObject);
	}
}
