using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumyTG_Ctrl : MonoBehaviour {

    float ChangeTimer = 0;

    Rigidbody Body;

    // Use this for initialization
    void Start () {
        Body = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ChangeTimer < 0f)
        {
            float angle = Random.Range(0f, 2f*3.15f);
            float force = Random.Range(100f, 300f);
            Vector3 direction = new Vector3( Mathf.Sin(angle) ,0f , Mathf.Cos(angle));

            Body.AddForce(direction * force, ForceMode.Impulse);

            ChangeTimer = Random.Range(4f, 10f);
        }
        else
        {
            ChangeTimer -= Time.deltaTime;
        }

	}
}
