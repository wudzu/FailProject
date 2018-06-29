using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

	PathRequestManager requestManager;
	Grid grid;

	void Awake() {
		grid = GetComponent<Grid> ();
		requestManager = GetComponent<PathRequestManager> ();
	}

	/*void Update() {

			FindPath (seeker.position, target.position);
	}*/

	public void StartFindPath(Vector3 startPos, Vector3 targetPos) {
		StartCoroutine (FindPath(startPos, targetPos));
	}

	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos){

		Vector3[] waypoints = new Vector3[0];
		bool pathSuccess = false;

		Node startNode = grid.GetNodeFromWorldPoint (startPos);
		Node targetNode = grid.GetNodeFromWorldPoint (targetPos);

		if (startNode.isEmptySpace && targetNode.isEmptySpace) {
			Heap<Node> openSet = new Heap<Node> (grid.MaxSize);
			HashSet<Node> closedSet = new HashSet<Node> ();
			openSet.Add (startNode);

			while (openSet.Count > 0) {
				Node currentNode = openSet.RemoveFirst();
				closedSet.Add (currentNode);

				if (currentNode == targetNode) {
					pathSuccess = true;
					break;
				}

				foreach (Node neighbure in grid.GetNeighbours(currentNode)) {
					if (!neighbure.isEmptySpace || closedSet.Contains (neighbure)) {
						continue;
					}

					int newMovementCostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbure) + neighbure.terainCost;
					if (newMovementCostToNeighbour < neighbure.gCost || !openSet.Contains (neighbure)) {
						neighbure.gCost = newMovementCostToNeighbour;
						neighbure.hCost = GetDistance(neighbure, targetNode);
						neighbure.parent = currentNode;

						if (!openSet.Contains (neighbure)) {
							openSet.Add (neighbure);
						} else {
							openSet.UpdateItem (neighbure);
						}

					}


				}
			}
		}

		yield return null;

		if (pathSuccess) {
			waypoints = RetracePath (startNode, targetNode);
		} 

		requestManager.FinishedProcessingPath (waypoints, pathSuccess);
	}

	Vector3[] RetracePath(Node startNode, Node endNode){
		List<Node> path = new List<Node> ();
		Node currentNode = endNode;

		while(currentNode != startNode){
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}

		Vector3[] waypoints = SimplifyPath (path);			

		Array.Reverse(waypoints);

		return waypoints;
	}

	Vector3[] SimplifyPath(List<Node> path) {
		if (path.Count < 1)
			return new Vector3[0];

		List<Vector3> waypoints = new List<Vector3> ();
		Vector2 directionOld = Vector2.zero;
						
		for (int i = 1; i<path.Count; i++){
			Vector2 directionNew = new Vector2(path[i-1].gridX - path[i].gridX, path[i-1].gridY - path[i].gridY);
			if(directionNew != directionOld){
				waypoints.Add(path[i].worldPosition);
			}

			directionOld = directionNew;
		}

		waypoints.Add(path[path.Count-1].worldPosition);

		return waypoints.ToArray();
	}
	int GetDistance(Node nodeA, Node nodeB){
		int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);
	
		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}
}
