using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_display : MonoBehaviour {

    public float Display_height = -0.49f;

    public Terain_ctrl AreneTerrain_Controler;

    /* ------------------------------------------------ */
    /*  simplified terain generation:                   */
    /*  - uses only single sprite for each tarain tylpe */
    
    public GameObject Terrain_obj;
    public Sprite[] Terrain_Sprites;
    public Color[] Terrain_Collors;
    public GameObject container;

    Vector2 TileSize = new Vector2(2f, 2f);

    List<GameObject> TarrainTiles;

    /* [TO DO] add handling cases where map tile has different size than sprite */
    void Reset_terain_Display()
    {
        int ArraySize_X = AreneTerrain_Controler.TerainArray.GetLength(0);
        int ArraySize_Y = AreneTerrain_Controler.TerainArray.GetLength(1);

        foreach(GameObject tile in TarrainTiles)
        {
            Destroy(tile);
            TarrainTiles.Remove(tile);
        }

        Vector3 BasePosition = new Vector3(AreneTerrain_Controler.Tarain_origin.x, Display_height, AreneTerrain_Controler.Tarain_origin.y);
        GameObject Tile_parent;

        if (container)
            Tile_parent = container;
        else
            Tile_parent = gameObject;

        for (int Xidx = 0; Xidx < ArraySize_X; Xidx++)
            for (int Yidx = 0; Yidx < ArraySize_Y; Yidx++)
            {

                GameObject newTile = Instantiate(Terrain_obj, Tile_parent.transform);
                TarrainTiles.Add(newTile);

                Vector3 newPosition = new Vector3(2f * (float)Xidx, 0f, 2f * (float)Yidx) + BasePosition;
                
                newTile.transform.localPosition = newPosition;

                Terain_types Tile_Terain = AreneTerrain_Controler.TerainArray[Xidx, Yidx];

                SpriteRenderer Tile_sprite = newTile.GetComponent<SpriteRenderer>();

                if( ((int)Tile_Terain) < Terrain_Sprites.Length)
                {
                    Tile_sprite.sprite = Terrain_Sprites[(int)Tile_Terain];
                }
                if (((int)Tile_Terain) < Terrain_Collors.Length)
                {
                    Tile_sprite.color = Terrain_Collors[(int)Tile_Terain];
                }
            }


    }


    // Use this for initialization
    void Start () {
        TarrainTiles = new List<GameObject>();

        Reset_terain_Display();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
