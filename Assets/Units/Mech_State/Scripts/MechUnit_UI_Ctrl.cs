using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechUnit_UI_Ctrl : MonoBehaviour {

    public UnityEngine.UI.Text TempTextUI;
    public bool DisplayHP_Bar = false;
    
    public GameObject HP_Bar_prefab;
    HP_bar_Ctrl HP_Bar = null;

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
        else if(HP_Bar)
        {

            List<float> tempList = new List<float>();
            foreach(MechArmor ArlorLayer in Armors)
            {
                /* [TO DO] add limitation to armor level, max 100 as in 100% */
                tempList.Add(ArlorLayer.getStructure());
            }

            HP_Bar.Update_display_Levels(HP, tempList);
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
        if (DisplayHP_Bar)
        {
            GameObject GlobalCanvas = GameObject.Find("UI/Canvas");
            GameObject New_HP_Bar = Instantiate(HP_Bar_prefab, GlobalCanvas.transform);
            HP_Bar = New_HP_Bar.GetComponent<HP_bar_Ctrl>();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (HP_Bar)
        {
            HP_Bar.Update_Position(gameObject);
        }
    }
}
