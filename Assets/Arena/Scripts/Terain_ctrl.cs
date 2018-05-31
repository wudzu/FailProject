using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Terain_types { Ground, Road, Sand, Water, Acid, NumberOfElements}

public class Terain_ctrl : MonoBehaviour {

    Vector2 Map_Size = new Vector2(40f,40f);
    Vector2 Tile_Size = new Vector2(2f,2f);

    /* ----------------------------------------- */
    /* Processing and preparing the terain array */

    bool Tarain_Ready_shadow = false;
    public bool Tarain_Ready
    {
        get
        {
            return Tarain_Ready_shadow;
        }
    }


    public void Change_TerainParameters(Vector2 map_size, Vector2 tile_size)
    {
        Tarain_Ready_shadow = false;
        /* sanity check for new values */
        if ( map_size.x <= 0f ||
            map_size.y <= 0f ||
            tile_size.x <= 0f ||
            tile_size.y <= 0f)
        {
            Debug.Log("Change_TerainParameters: request for negaticve size of terain elements ! ");
            return;
        }

        // update parameters
        Map_Size = map_size;
        Tile_Size = tile_size;

        // re initialize tarain array
        ReloadTerains();
    }

    // use a random or predetermined terain layout
    public bool Terein_Randomized_shadow = false;
    public bool Terein_Randomized
    {
        set
        {
            Tarain_Ready_shadow = false;
            Terein_Randomized_shadow = value;
            ReloadTerains(); // update imidiatly
        }
        get
        {
            return Terein_Randomized_shadow;
        }
    }

    private Terain_types[,] TerainArray_shadow = new Terain_types[1,1];

    public void ReloadTerains()
    {
        int ArraySize_X = Mathf.CeilToInt(Map_Size.x / Tile_Size.x);
        int ArraySize_Y = Mathf.CeilToInt(Map_Size.y / Tile_Size.y);

        TerainArray_shadow = new Terain_types[ArraySize_X, ArraySize_Y];

        if (Terein_Randomized)
        {

            System.Random RNG_gen = new System.Random();
            
            for(int Xidx=0; Xidx< ArraySize_X; Xidx++)
                for (int Yidx = 0; Yidx < ArraySize_Y; Yidx++)
                {
                    int range = (int)Terain_types.NumberOfElements;
                    TerainArray_shadow[Xidx, Yidx] = (Terain_types)(RNG_gen.Next(range));
                }
        }
        else
        {
            // lets go with circular pattern
            float range = (float)Terain_types.NumberOfElements;
            float angle_width = 2 * Mathf.PI / range;
            
            for (int Xidx = 0; Xidx < ArraySize_X; Xidx++)
                for (int Yidx = 0; Yidx < ArraySize_Y; Yidx++)
                {
                    float angle = Mathf.Atan2((float)(Yidx - ArraySize_Y/2), (float)(Xidx - ArraySize_X/2));

                    int terainIndex = Mathf.FloorToInt((Mathf.PI + angle) / angle_width);
                    TerainArray_shadow[Xidx, Yidx] = (Terain_types)(terainIndex);
                }

        }

        Tarain_Ready_shadow = true;

    }

    /* ------------------------------ */
    /* Interface to obtin terain data */

    public Vector2 Tarain_origin = new Vector2(-20f, -20f);


    public Terain_types GetTerainAt(Vector2 cordinates)
    {
        if (!Tarain_Ready_shadow)
        {
            ReloadTerains();
        }

        Vector2 point = cordinates - Tarain_origin;
        int arrayIdx_X = Mathf.FloorToInt(point.x / Tile_Size.x);
        int arrayIdx_Y = Mathf.FloorToInt(point.y / Tile_Size.y);

        if (arrayIdx_X >= 0 &&
            arrayIdx_X < TerainArray_shadow.GetLength(0) &&
            arrayIdx_Y >= 0 &&
            arrayIdx_Y < TerainArray_shadow.GetLength(1) )
        {

            return TerainArray_shadow[arrayIdx_X, arrayIdx_Y];
        }

        Debug.Log(" GetTerainAt: incorrect coordinates or terain array. /n"+
                  "   coordinates: " + cordinates.ToString() + " /n" +
                  "   terain array: " + TerainArray_shadow.GetLongLength(0).ToString()+ " , " + TerainArray_shadow.GetLongLength(0).ToString() + " /n");
        return Terain_types.Ground;
    }


    public Terain_types[,] TerainArray
    {
        get
        {
            if( !Tarain_Ready_shadow)
            {
                ReloadTerains();
            }
            return TerainArray_shadow;
        }
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
