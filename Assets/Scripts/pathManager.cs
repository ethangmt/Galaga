using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour {

	public static List<Vector2> path1;

	// Use this for initialization
	void Start () {
		path1 = GameObject.Find ("enemyInitialPathLeft").GetComponent<path> ().cPath;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
