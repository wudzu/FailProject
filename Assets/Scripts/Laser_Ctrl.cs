using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Ctrl : MonoBehaviour {

    public Main_controller ScoreBordCtrl;
    public float TTL = 10f; // laser bullet time-to-live
    public float Speed = 10f;

    public GameObject Las_Explosion_prefab;

    // Use this for initialization
    void Start () {

    }

    void Explode()
    {
        // add particle efect of laset explosion
        GameObject TempExplosion = Instantiate(Las_Explosion_prefab, transform.position, transform.rotation);
        //TempExplosion.transform.localPosition = new Vector3(0f, 0f, 0f);

        // selfdestroy to ensure no pasing through objects
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            ScoreBordCtrl.AddScore();
            Explode();
        }
        if(other.tag == "Env")
        {
            Explode();
        }
    }

    // Update is called once per frame
    void Update () {

        // self-destroy the bulet after time
        TTL -= Time.deltaTime;
        if( TTL < 0f)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.up * Time.deltaTime* Speed);


    }
}
