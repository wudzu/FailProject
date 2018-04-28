using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponCollider : MonoBehaviour {

    public int W_Collider_Idx = 0;
    public Wepon_Ctrl Wepon = null;

    void Start()
    {
        if (Wepon == null)
        {
            Debug.Log(" ERROR: wepon colider not assigned ! ");
        }
        if (W_Collider_Idx == 0)
        {
            Debug.Log(" ERROR: wepon colider index not assigned ! ");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Wepon)
        {
            Wepon.Wepon_Colider_Hit(W_Collider_Idx, collision);
        }
    }
    
}
