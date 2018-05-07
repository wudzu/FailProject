using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_Ctrl : MonoBehaviour {

    public UnityEngine.UI.Text TempTextUI;

    void SetStatusText( float HP, float Energy, List<MechArmor> Armors )
    {

        if (TempTextUI)
        {
            TempTextUI.text = "Player 1\n\n  Core: ";
            TempTextUI.text += HP.ToString();
            foreach(MechArmor Armor_layer in Armors)
            {
                TempTextUI.text += "\n  Armor (" + Armor_layer.getName() + ") : " + Armor_layer.getStructure().ToString();
            }

            TempTextUI.text += "\n\n  Energy: ";
            TempTextUI.text += Energy.ToString();
        }
        else
        {
            Debug.Log("SetStatusText: UI object not connected ! ");
        }

    }

    public void Update_Mech_state_display( float HP, float Energy, List<MechArmor> Armors)
    {
        SetStatusText(HP, Energy, Armors);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
