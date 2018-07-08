using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechState : MonoBehaviour
{

    public MechUnit_UI_Ctrl UI_interface;
    public int UI_interface_Index =0;

    MechCore core = new MechCore();
	List<MechArmor> armor = new List<MechArmor>();

	public List<string> getArmorName()
	{
		List<string> result = new List<string>();
		foreach (MechArmor arm in armor) {
			string temp = arm.getName();
			result.Add(temp);
		}
		return result;
	}

	public List<float> getArmorStructure()
	{
		List<float> result = new List<float>();
		foreach (MechArmor arm in armor) {
			float temp = arm.getStructure();
			result.Add(temp);
		}
		return result;
	}

	public float getEnergy()
	{
		return core.Get_Energy_Level ();
	}

	public float movementEnergyDrain(float force)
	{
		return core.EnergyDrainMovement (force);
	}

	public bool EnergyDrainWeapon (float force)
	{
		return core.EnergyDrainWeapon(force);
	}

	public void damage (MechDamage dmg)
	{

        // Debug.Log("MechState1: " + dmg.basicDamage["Blunt"].ToString() +
        //                     " , " + dmg.basicDamage["Cut"].ToString() +
        //                     " , " + dmg.basicDamage["Pierce"].ToString() +
        //                     " , " + dmg.basicDamage["Abrasive"].ToString());

        foreach (MechArmor arm in armor)
		{
			dmg = arm.damage(dmg);
        }

        // Debug.Log("MechState2: " + dmg.basicDamage["Blunt"].ToString() +
        //                     " , " + dmg.basicDamage["Cut"].ToString() +
        //                     " , " + dmg.basicDamage["Pierce"].ToString() +
        //                     " , " + dmg.basicDamage["Abrasive"].ToString());

        core.damage(dmg);
        
        /*
		if (core.ifStun()) {
			//Stun mech
		}

		if (core.ifDead() ) {
			//Kill mech
		}*/

        /* Update displayed mech status */
        UI_interface.Update_Mech_state_display(UI_interface_Index, core.Get_HP_Level(), core.Get_Energy_Level(), armor);
    }

	// Use this for initialization
	void Start ()
	{
		MechArmor a = new MechArmor();
		MechArmor b = new MechArmor();
		MechArmor c = new MechArmor();
		a.LoadNew("MetalHard");
		b.LoadNew("MetalSoft");
		c.LoadNew("Ammortization");

		armor.Add(a);
		armor.Add(b);
		armor.Add(c);

		core.start();

        /* initialize mech status displayed in UI */
        UI_interface.Update_Mech_state_display(UI_interface_Index, core.Get_HP_Level(), core.Get_Energy_Level(), armor);

    }
	
	// Update is called once per frame
	void Update ()
	{
        core.CoreUpdate(Time.deltaTime);

        UI_interface.Update_Mech_state_display(UI_interface_Index, core.Get_HP_Level(), core.Get_Energy_Level(), armor);
    }
}

