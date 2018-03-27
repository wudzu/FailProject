using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_Ctrl : MonoBehaviour {

    public GameObject BaseBat;
    public Animator anim;
    public GameObject LasGun;

    public GameObject Las_Prefab;
    public Main_controller Score_ctrl;


    Vector3 Basic_gunPos = new Vector3(0.14f, 1.1f, 0.2f);
    Vector3 LaserCristalChamber_Pos = new Vector3(0.14f, 1.122f, 0.3f) ;
    int WeponSel = 0;

    void SelectWepon( int selector)
    {
        switch (selector)
        {
            case 1:
                BaseBat.SetActive( true);
                LasGun.SetActive( false);
                break;
            case 2:
                BaseBat.SetActive(false);
                LasGun.SetActive(true);
                break;
            default:
                BaseBat.SetActive(false);
                LasGun.SetActive(false);
                break;
        }


       
    }

    void ShootLaser()
    {
        GameObject TempLas = Instantiate(Las_Prefab,transform, false);
       // TempLas.transform.localPosition = LaserCristalChamber_Pos;    // why not working ?!?!
        TempLas.transform.localPosition = new Vector3(0.14f, 1.122f, 0.3f);
        TempLas.transform.parent = null;
        TempLas.GetComponent<Laser_Ctrl>().ScoreBordCtrl = Score_ctrl;
    }

    // Use this for initialization
    void Start () {
        LaserCristalChamber_Pos = new Vector3(0.14f, 1.122f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
		
        // check if attak key is pressed
        if(Input.GetKeyDown("x"))
        {
            if(WeponSel == 1)
            {
                anim.Play("BatSwing");
            }
            else if(WeponSel == 2)
            {
                ShootLaser();
            }
        }

        // check if wepon selection is changed
        if (Input.GetKeyDown("1"))
        {
            WeponSel = (WeponSel == 1) ? (0) : (1) ;
            SelectWepon(WeponSel);
        }
        if (Input.GetKeyDown("2"))
        {
            WeponSel = (WeponSel == 2) ? (0) : (2);
            SelectWepon(WeponSel);
        }

    }
}
