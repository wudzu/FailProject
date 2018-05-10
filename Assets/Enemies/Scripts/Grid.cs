using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;


	int gridSizeX, gridSizeY;
	float nodeWidth;

	void Start(){

		nodeWidth = 2 * nodeRadius;
		gridSizeX = Mathf.RoundToInt (gridWorldSize.x/nodeWidth);
		gridSizeY = Mathf.RoundToInt (gridWorldSize.y/nodeWidth);

		CreateGrid ();
	}

	void CreateGrid(){
		Vector3 worldPoint;
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

		grid = new Node[gridSizeX, gridSizeY];

		for (int x = 0; x < gridSizeX; x++) {
			for (int y = 0; y < gridSizeY; y++) {
				worldPoint = worldBottomLeft + Vector3.right * (x * nodeWidth + nodeRadius) + Vector3.forward * (y * nodeWidth + nodeRadius);
				grid[x,y] = new Node(!(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)), worldPoint, x, y);
			}
		}
	}

	public Node GetNodeFromWorldPoint(Vector3 worldPoint){
		float percentX = Mathf.Clamp01((worldPoint.x + gridWorldSize.x / 2) / gridWorldSize.x);
		float percentY = Mathf.Clamp01((worldPoint.z + gridWorldSize.y / 2) / gridWorldSize.y);
	
		int x = Mathf.RoundToInt((gridSizeX-1)*percentX);
		int y = Mathf.RoundToInt((gridSizeY-1)*percentY);

		return grid[x,y];
	}

	public List<Node> GetNeighbours(Node node){
		List<Node> neighbour = new List<Node> ();

		for(int x = -1; x <= 1; x++){
			for(int y = -1; y <= 1; y++){
				if (x == 0 && y == 0)
					continue;

				int currentX = node.gridX + x;
				int currentY = node.gridY + y;

				if (currentX >= 0 && currentX < gridSizeX && currentY >= 0 && currentY < gridSizeY) {
					neighbour.Add (grid [currentX, currentY]);
				}
			}
		}

		return neighbour;
	}

	public List<Node> path;

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

		if (grid != null) {
			foreach (Node n in grid){
				Gizmos.color = (n.isEmptySpace) ? Color.white : Color.red;
				if (path != null) {
					if (path.Contains (n)) {
						Gizmos.color = Color.black;
					}
				}

				Gizmos.DrawCube (n.worldPosition, Vector3.one*(nodeWidth - 0.1f));
			}
		
		}
			
	}
}
