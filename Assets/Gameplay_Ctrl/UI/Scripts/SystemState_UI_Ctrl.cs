using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemState_UI_Ctrl : MonoBehaviour {

    public UnityEngine.UI.Text TempTextUI;
    public Rigidbody Player1Body;
    public Rigidbody Player2Body;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (TempTextUI)
        {
            TempTextUI.text = "FPS: ";
            TempTextUI.text += (1f / Time.deltaTime).ToString();

            TempTextUI.text += "\n\nMechSpeed (L): ";
            TempTextUI.text += Player1Body.velocity.ToString();

            TempTextUI.text += "\nMechSpeed (R): ";
            TempTextUI.text += Player2Body.velocity.ToString();
        }
        else
        {
            Debug.Log("System Status UI object not connected ! ");
        }
    }
}
