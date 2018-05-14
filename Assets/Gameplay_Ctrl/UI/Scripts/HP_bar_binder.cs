using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_bar_binder : MonoBehaviour {

    public GameObject HP_Bar_prefab;

    HP_bar_Ctrl HP_Bar = null;

	// Use this for initialization
	void Start () {

        GameObject GlobalCanvas = GameObject.Find("UI/Canvas");

        GameObject New_HP_Bar = Instantiate(HP_Bar_prefab, GlobalCanvas.transform);

        HP_Bar = New_HP_Bar.GetComponent<HP_bar_Ctrl>();
    }
	
	// Update is called once per frame
	void Update () {

        if (HP_Bar)
        {
            HP_Bar.Update_Position(gameObject);
        }

	}
}
