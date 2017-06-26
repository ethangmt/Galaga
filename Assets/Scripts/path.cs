using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

	public List<Vector2> cPath;
	public List<Vector3> points;

	public static path instance = null;

	void Start () {
		if (instance == null) {
			instance = this;
		} 
		else if (instance != this) {
			Destroy (instance);
		}
	}

	public void followPoint (GameObject obj, Vector2 point, float mspeed) {
		obj.GetComponent<Transform>().position = Vector2.MoveTowards (obj.GetComponent<Transform>().position, point, mspeed);
	}

	public int followPath (GameObject obj, List<Vector2> path, float mspeed, int index) {
		Vector2 objp = obj.GetComponent<Transform> ().position;
		// if object isn't in path[index] goto path[index]
		if (objp.x != path [index].x && objp.y != path [index].y) {
			followPoint (obj, path [index], mspeed);
		} 
		else {
			// goto next node
			index += 1;
		}
		// external objects keeps track of index
		return index;
	}

	void OnDrawGizmos () {
		// Reset point list
		points = new List<Vector3> ();
		cPath = new List<Vector2> ();
		// Add this item to list
		points.Add (GetComponent<Transform> ().position);
		// Add items to list
		foreach (Transform i in GetComponentInChildren<Transform>()) {
			points.Add (i.position);
		}
			
		for (int i = 0; i < points.Count; i++) {
			Gizmos.DrawSphere (points[i], 4f);

			if (i != 0) {
				Gizmos.DrawLine (points[i - 1], points[i]);
			}
		}

		// Add items to vector2 list
		for (int i = 0; i < points.Count; i++) {
			if (!cPath.Contains(new Vector2 (points [i].x, points [i].y))) {
				cPath.Add (new Vector2(points[i].x, points[i].y));
			}
		}

	}
}
