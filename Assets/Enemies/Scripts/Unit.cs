using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public Transform target;

	float speed = 1f;
	Vector3[] path;
	int targetIndex;
	Node previousTargetNode;
	Grid grid;

	void Awake(){
		grid = FindObjectOfType<Grid> ();
	}

	// Use this for initialization
	void Start () {

		Node currentTargetNode = grid.GetNodeFromWorldPoint (target.position);
		Node currentSeekerNode = grid.GetNodeFromWorldPoint (transform.position);

		if (currentTargetNode != currentSeekerNode) {
			PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);		
		}

		previousTargetNode = currentTargetNode;
	}

	void Update() {
		Node currentTargetNode = grid.GetNodeFromWorldPoint (target.position);
		Node currentSeekerNode = grid.GetNodeFromWorldPoint (transform.position);

		if (currentTargetNode != previousTargetNode) {

			if (currentTargetNode != currentSeekerNode) {
				PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);	
			}

			previousTargetNode = currentTargetNode;
		}
	}


	public void OnPathFound (Vector3[] newPath, bool pathSuccesful){
		if (pathSuccesful) {
			path = newPath;
			StopCoroutine ("FollowPath");
			StartCoroutine ("FollowPath");
		}
	}

	IEnumerator FollowPath(){
		Vector3 currentWaypoint = path [0];
		targetIndex = 0;

		Debug.Log ("Start Following Path");

		while (true) {
			Debug.Log ("Follow Path");
			if (transform.position == currentWaypoint) {
				targetIndex++;
				if (targetIndex >= path.Length) {
					yield break;
				}

				currentWaypoint = path [targetIndex];
			}

			transform.position = Vector3.MoveTowards (transform.position, currentWaypoint, speed*Time.deltaTime);
			yield return null;
		}
	}

	public void OnDrawGizmos(){
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i++) {
				Gizmos.color = Color.red;
				Gizmos.DrawCube (path [i], Vector3.one*0.5f);

				if (i == targetIndex) {
					Gizmos.DrawLine (transform.position, path [i]);
				}
				else{
					Gizmos.DrawLine (path[i-1], path [i]);
				}
			}
			
		}
	}

}
