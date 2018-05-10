using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
	public bool isEmptySpace;
	public Vector3 worldPosition;

	public Node parent;

	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;

	public int fCost{
		get {
			return gCost + hCost;
		}
	}

	public Node (bool _isEmpty, Vector3 _worldPos, int _gridX, int _gridY){
		isEmptySpace = _isEmpty;
		worldPosition = _worldPos;

		gridX = _gridX;
		gridY = _gridY;
	}

}
