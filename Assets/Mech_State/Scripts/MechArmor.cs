using UnityEngine;
using System.Collections;

public class MechArmor
{
	var change   = new Dictionary<string, float>();
	var reduction = new Dictionary<string, float>();
	var destruction = new Dictionary<string, float>();

	public enum A_Type { MetalSoft, MetalHard, Ammortization };
	float structure;

	//var Temperature;

	float mass;

	//var other;

	MechDamage reduct(MechDamage dmg)
	{
		
	}

	MechDamage damage(MechDamage dmg)
	{
		dmg.basicDamage["Blunt"] = dmg.basicDamage["Blunt"]
	}

	void LoadNew(A_Type armor)
	{
		switch (armor) {
		case A_Type.MetalSoft:
			change ["Blunt_to_Blunt"] = 1.0;
			change ["Cut_to_Blunt"] = 1.0;
			change ["Pierce_to_Blunt"] = 1.0;
			change ["Abrasive_to_Blunt"] = 0.0;

			change ["Blunt_to_Cut"] = 0.0;
			change ["Cut_to_Cut"] = 0.0;
			change ["Pierce_to_Cut"] = 0.0;
			change ["Abrasive_to_Cut"] = 0.0;

			change ["Blunt_to_Pierce"] = 0.0;
			change ["Cut_to_Pierce"] = 0.0;
			change ["Pierce_to_Pierce"] = 0.0;
			change ["Abrasive_to_Pierce"] = 0.0;

			change ["Blunt_to_Abrasive"] = 0.0;
			change ["Cut_to_Abrasive"] = 0.0;
			change ["Pierce_to_Abrasive"] = 0.0;
			change ["Abrasive_to_Abrasive"] = 1.0;

			reduction ["Blunt"] = 0.12;
			reduction ["Cut"] = 0.0;
			reduction ["Pierce"] = 0.0;
			reduction ["Abrasive"] = 0.8;

			destruction ["Blunt"] = 0.1;
			destruction ["Cut"] = 0.4;
			destruction ["Pierce"] = 0.4;
			destruction ["Abrasive"] = 0.5;

			structure = 100.0;
			mass = 8.0;

			break;
		
		case A_Type.MetalHard:
			change ["Blunt_to_Blunt"] = 1.0;
			change ["Cut_to_Blunt"] = 1.0;
			change ["Pierce_to_Blunt"] = 1.0;
			change ["Abrasive_to_Blunt"] = 0.0;

			change ["Blunt_to_Cut"] = 0.0;
			change ["Cut_to_Cut"] = 0.0;
			change ["Pierce_to_Cut"] = 0.0;
			change ["Abrasive_to_Cut"] = 0.0;

			change ["Blunt_to_Pierce"] = 0.0;
			change ["Cut_to_Pierce"] = 0.0;
			change ["Pierce_to_Pierce"] = 0.0;
			change ["Abrasive_to_Pierce"] = 0.0;

			change ["Blunt_to_Abrasive"] = 0.0;
			change ["Cut_to_Abrasive"] = 0.0;
			change ["Pierce_to_Abrasive"] = 0.0;
			change ["Abrasive_to_Abrasive"] = 1.0;

			reduction ["Blunt"] = 0.1;
			reduction ["Cut"] = 0.0;
			reduction ["Pierce"] = 0.0;
			reduction ["Abrasive"] = 0.6;

			destruction ["Blunt"] = 0.5;
			destruction ["Cut"] = 0.1;
			destruction ["Pierce"] = 0.1;
			destruction ["Abrasive"] = 1.0;

			structure = 100.0;
			mass = 10.0;

			break;

		case A_Type.Ammortization:
			change ["Blunt_to_Blunt"] = 1.0;
			change ["Cut_to_Blunt"] = 0.0;
			change ["Pierce_to_Blunt"] = 0.0;
			change ["Abrasive_to_Blunt"] = 0.0;

			change ["Blunt_to_Cut"] = 0.0;
			change ["Cut_to_Cut"] = 1.0;
			change ["Pierce_to_Cut"] = 0.0;
			change ["Abrasive_to_Cut"] = 0.0;

			change ["Blunt_to_Pierce"] = 0.0;
			change ["Cut_to_Pierce"] = 0.0;
			change ["Pierce_to_Pierce"] = 1.0;
			change ["Abrasive_to_Pierce"] = 0.0;

			change ["Blunt_to_Abrasive"] = 0.0;
			change ["Cut_to_Abrasive"] = 0.0;
			change ["Pierce_to_Abrasive"] = 0.0;
			change ["Abrasive_to_Abrasive"] = 1.0;

			reduction ["Blunt"] = 0.8;
			reduction ["Cut"] = 0.0;
			reduction ["Pierce"] = 0.0;
			reduction ["Abrasive"] = 0.0;

			destruction ["Blunt"] = 0.02;
			destruction ["Cut"] = 0.5;
			destruction ["Pierce"] = 0.5;
			destruction ["Abrasive"] = 0.9;

			structure = 100.0;
			mass = 7.0;

			break;
		}
	}
}

