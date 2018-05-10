using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
	public Transform seeker, target;

	Grid grid;

	void Awake() {
		grid = GetComponent<Grid> ();
	}

	void Update() {
		//if(Input.GetKeyDown(KeyCode.P))
			FindPath (seeker.position, target.position);
	}

	void FindPath(Vector3 startPos, Vector3 targetPos){
		Node startNode = grid.GetNodeFromWorldPoint (startPos);
		Node targetNode = grid.GetNodeFromWorldPoint (targetPos);

		Heap<Node> openSet = new Heap<Node> (grid.MaxSize);
		HashSet<Node> closedSet = new HashSet<Node> ();
		openSet.Add (startNode);

		while (openSet.Count > 0) {
			Node currentNode = openSet.RemoveFirst();
			closedSet.Add (currentNode);

			if (currentNode == targetNode) {
				RetracePath (startNode, targetNode);
				return;
			}
							
			foreach (Node neighbure in grid.GetNeighbours(currentNode)) {
				if (!neighbure.isEmptySpace || closedSet.Contains (neighbure)) {
					continue;
				}
			
				int newMovementCostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbure);
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

	void RetracePath(Node startNode, Node endNode){
		List<Node> path = new List<Node> ();
		Node currentNode = endNode;

		while(currentNode != startNode){
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}

		path.Reverse();

		grid.path = path;
	}

	int GetDistance(Node nodeA, Node nodeB){
		int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);
	
		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}
}
