using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;

	bool levelStart = false;
	int enemy = 2;
	float speedDecrease = .3f; //.3f

	List<GameObject> enemies = new List<GameObject>();
	List<int> index = new List<int> ();
	List<float> maxSpeed = new List<float> ();

	//TODO delay enemy movement
	// create beginLevel method, instantiate enemies there 

	// Use this for initialization
	void Start () {
		// level 1

	}
	
	// Update is called once per frame
	void Update () {
		if (!levelStart) {
			initiateLevel ();
		}

		beginLevel ();


	}

	void initiateLevel () {
		for (int i = 0; i < enemy; i++) {
			enemies.Add(Instantiate (enemy1, new Vector2(pathManager.path1[0].x - 1, pathManager.path1[0].y - 1), Quaternion.identity));
			maxSpeed.Add (1 - (speedDecrease * i));
			index.Add (0);
		}
		levelStart = true;
	}

	void beginLevel () {
		for (int i = 0; i < index.Count; i++) {
			if (index[i] < pathManager.path1.Count) {
				index[i] = path.instance.followPath (enemies[i], pathManager.path1, maxSpeed[i], index[i]);
				//StartCoroutine ("wait", 100f * i);
			}
		}
	}

	void updateLevel () {
	
	}

	// TODO doesn't work in update, rm
	IEnumerator wait (float wait) {
		yield return new WaitForSecondsRealtime (wait);
	}
}
