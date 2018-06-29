using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node> {
	public bool isEmptySpace;
	public Vector3 worldPosition;

	public Node parent;

	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public int terainCost;

	int heapIndex;

	public int fCost{
		get {
			return gCost + hCost;
		}
	}

	public Node (bool _isEmpty, Vector3 _worldPos, int _gridX, int _gridY, int _terainCost){
		isEmptySpace = _isEmpty;
		worldPosition = _worldPos;

		gridX = _gridX;
		gridY = _gridY;
		terainCost = _terainCost;
	}


	public int HeapIndex {
		get{
			return heapIndex;
		}		
		set {
			heapIndex = value;
		}
	}

	public int CompareTo(Node node){
		int compare = fCost.CompareTo (node.fCost);
		if (compare == 0) {
			compare = hCost.CompareTo (node.hCost);
		}
	
		return -compare;
	}
}
