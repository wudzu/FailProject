using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_SelfDestruct : MonoBehaviour {


    public float TTL = 0.5f; // laser explosion time-to-live
    
	// Update is called once per frame
	void Update () {

        // self-destroy the bulet after time
        TTL -= Time.deltaTime;
        if (TTL < 0f)
        {
            Destroy(gameObject);
        }
    }
}
