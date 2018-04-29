using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum A_Type { MetalSoft, MetalHard, Ammortization };


public class MechArmor
{
	Dictionary<string, float> change   = new Dictionary<string, float>();
	Dictionary<string, float> reduction = new Dictionary<string, float>();
	Dictionary<string, float> destruction = new Dictionary<string, float>();

	float structure;

	//var Temperature;

	float mass;

	//var other;

	MechDamage reduct(MechDamage dmg)
	{
		dmg.basicDamage ["Blunt"] = dmg.basicDamage ["Blunt"] * reduction ["Blunt"];
		dmg.basicDamage ["Cut"] = dmg.basicDamage ["Cut"] * reduction ["Cut"];
		dmg.basicDamage ["Pierce"] = dmg.basicDamage ["Pierce"] * reduction ["Pierce"];
		dmg.basicDamage ["Abrasive"] = dmg.basicDamage ["Abrasive"] * reduction ["Abrasive"];

		return dmg;
	}

	MechDamage changeDmg(MechDamage dmg)
	{
		dmg.basicDamage ["Blunt"] = dmg.basicDamage ["Blunt"] * change ["Blunt_to_Blunt"] +
									dmg.basicDamage ["Cut"] * change ["Cut_to_Blunt"] +
									dmg.basicDamage ["Pierce"] * change ["Pierce_to_Blunt"] +
									dmg.basicDamage ["Abrasive"] * change ["Abrasive_to_Blunt"];

		dmg.basicDamage ["Cut"] = dmg.basicDamage ["Blunt"] * change ["Blunt_to_Cut"] +
									dmg.basicDamage ["Cut"] * change ["Cut_to_Cut"] +
									dmg.basicDamage ["Pierce"] * change ["Pierce_to_Cut"] +
									dmg.basicDamage ["Abrasive"] * change ["Abrasive_to_Cut"];

		dmg.basicDamage ["Pierce"] = dmg.basicDamage ["Blunt"] * change ["Blunt_to_Pierce"] +
									dmg.basicDamage ["Cut"] * change ["Cut_to_Pierce"] +
									dmg.basicDamage ["Pierce"] * change ["Pierce_to_Pierce"] +
									dmg.basicDamage ["Abrasive"] * change ["Abrasive_to_Pierce"];

		dmg.basicDamage ["Abrasive"] = dmg.basicDamage ["Blunt"] * change ["Blunt_to_Abrasive"] +
									dmg.basicDamage ["Cut"] * change ["Cut_to_Abrasive"] +
									dmg.basicDamage ["Pierce"] * change ["Pierce_to_Abrasive"] +
									dmg.basicDamage ["Abrasive"] * change ["Abrasive_to_Abrasive"];

		return dmg;
	}

	void destruct(MechDamage dmg)
	{
		float structureDamage = dmg.basicDamage ["Blunt"] * destruction ["Blunt"] +
								dmg.basicDamage ["Cut"] * destruction ["Cut"] +
								dmg.basicDamage ["Pierce"] * destruction ["Pierce"] +
								dmg.basicDamage ["Abrasive"] * destruction ["Abrasive"];

		structure = structure - structureDamage;
	}

	public MechDamage damage(MechDamage dmg)
	{
		MechDamage reductedDmg = reduct (dmg);
		destruct (reductedDmg);
		MechDamage finalDmg = changeDmg (reductedDmg);

		return finalDmg;
	}

	public void LoadNew(A_Type armor)
	{
		switch (armor) {
		case A_Type.MetalSoft:
			change ["Blunt_to_Blunt"] = 1.0f;
			change ["Cut_to_Blunt"] = 1.0f;
			change ["Pierce_to_Blunt"] = 1.0f;
			change ["Abrasive_to_Blunt"] = 0.0f;

			change ["Blunt_to_Cut"] = 0.0f;
			change ["Cut_to_Cut"] = 0.0f;
			change ["Pierce_to_Cut"] = 0.0f;
			change ["Abrasive_to_Cut"] = 0.0f;

			change ["Blunt_to_Pierce"] = 0.0f;
			change ["Cut_to_Pierce"] = 0.0f;
			change ["Pierce_to_Pierce"] = 0.0f;
			change ["Abrasive_to_Pierce"] = 0.0f;

			change ["Blunt_to_Abrasive"] = 0.0f;
			change ["Cut_to_Abrasive"] = 0.0f;
			change ["Pierce_to_Abrasive"] = 0.0f;
			change ["Abrasive_to_Abrasive"] = 1.0f;

			reduction ["Blunt"] = 0.12f;
			reduction ["Cut"] = 0.0f;
			reduction ["Pierce"] = 0.0f;
			reduction ["Abrasive"] = 0.8f;

			destruction ["Blunt"] = 0.1f;
			destruction ["Cut"] = 0.4f;
			destruction ["Pierce"] = 0.4f;
			destruction ["Abrasive"] = 0.5f;

			structure = 100.0f;
			mass = 8.0f;

			break;
		
		case A_Type.MetalHard:
			change ["Blunt_to_Blunt"] = 1.0f;
			change ["Cut_to_Blunt"] = 1.0f;
			change ["Pierce_to_Blunt"] = 1.0f;
			change ["Abrasive_to_Blunt"] = 0.0f;

			change ["Blunt_to_Cut"] = 0.0f;
			change ["Cut_to_Cut"] = 0.0f;
			change ["Pierce_to_Cut"] = 0.0f;
			change ["Abrasive_to_Cut"] = 0.0f;

			change ["Blunt_to_Pierce"] = 0.0f;
			change ["Cut_to_Pierce"] = 0.0f;
			change ["Pierce_to_Pierce"] = 0.0f;
			change ["Abrasive_to_Pierce"] = 0.0f;

			change ["Blunt_to_Abrasive"] = 0.0f;
			change ["Cut_to_Abrasive"] = 0.0f;
			change ["Pierce_to_Abrasive"] = 0.0f;
			change ["Abrasive_to_Abrasive"] = 1.0f;

			reduction ["Blunt"] = 0.1f;
			reduction ["Cut"] = 0.0f;
			reduction ["Pierce"] = 0.0f;
			reduction ["Abrasive"] = 0.6f;

			destruction ["Blunt"] = 0.5f;
			destruction ["Cut"] = 0.1f;
			destruction ["Pierce"] = 0.1f;
			destruction ["Abrasive"] = 1.0f;

			structure = 100.0f;
			mass = 10.0f;

			break;

		case A_Type.Ammortization:
			change ["Blunt_to_Blunt"] = 1.0f;
			change ["Cut_to_Blunt"] = 0.0f;
			change ["Pierce_to_Blunt"] = 0.0f;
			change ["Abrasive_to_Blunt"] = 0.0f;

			change ["Blunt_to_Cut"] = 0.0f;
			change ["Cut_to_Cut"] = 1.0f;
			change ["Pierce_to_Cut"] = 0.0f;
			change ["Abrasive_to_Cut"] = 0.0f;

			change ["Blunt_to_Pierce"] = 0.0f;
			change ["Cut_to_Pierce"] = 0.0f;
			change ["Pierce_to_Pierce"] = 1.0f;
			change ["Abrasive_to_Pierce"] = 0.0f;

			change ["Blunt_to_Abrasive"] = 0.0f;
			change ["Cut_to_Abrasive"] = 0.0f;
			change ["Pierce_to_Abrasive"] = 0.0f;
			change ["Abrasive_to_Abrasive"] = 1.0f;

			reduction ["Blunt"] = 0.8f;
			reduction ["Cut"] = 0.0f;
			reduction ["Pierce"] = 0.0f;
			reduction ["Abrasive"] = 0.0f;

			destruction ["Blunt"] = 0.02f;
			destruction ["Cut"] = 0.5f;
			destruction ["Pierce"] = 0.5f;
			destruction ["Abrasive"] = 0.9f;

			structure = 100.0f;
			mass = 7.0f;

			break;
		}
	}
}

