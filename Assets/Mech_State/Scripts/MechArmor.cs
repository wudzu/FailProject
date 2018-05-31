using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MechArmor
{
	Dictionary<string, float> change   = new Dictionary<string, float>();
	Dictionary<string, float> reduction = new Dictionary<string, float>();
	Dictionary<string, float> destruction = new Dictionary<string, float>();

	string name;

	public string getName()
	{
		return name;
	}

	float structure;

	public float getStructure()
	{
		return structure;
	}

	//var Temperature;

	float mass;

	//var other;

	MechDamage reduct(MechDamage dmg)
	{
		dmg.basicDamage ["Blunt"] = dmg.basicDamage ["Blunt"] * (1 - (reduction ["Blunt"] * structure / 100.0f));
		dmg.basicDamage ["Cut"] = dmg.basicDamage ["Cut"] * (1 - (reduction ["Cut"] * structure / 100.0f));
		dmg.basicDamage ["Pierce"] = dmg.basicDamage ["Pierce"] * (1 - (reduction ["Pierce"] * structure / 100.0f));
		dmg.basicDamage ["Abrasive"] = dmg.basicDamage ["Abrasive"] * (1 - (reduction ["Abrasive"] * structure / 100.0f));

		return dmg;
	}

	MechDamage changeDmg(MechDamage dmg)
	{
		dmg.basicDamage ["Blunt"] = dmg.basicDamage ["Blunt"] * (((change ["Blunt_to_Blunt"]  * structure) + (100.0f - structure) ) / 100.0f ) +
								dmg.basicDamage ["Cut"] * (((change ["Cut_to_Blunt"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Pierce"] * (((change ["Pierce_to_Blunt"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Abrasive"] * (((change ["Abrasive_to_Blunt"]  * structure)) / 100.0f );

		dmg.basicDamage ["Cut"] = dmg.basicDamage ["Blunt"] * (((change ["Blunt_to_Cut"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Cut"] * (((change ["Cut_to_Cut"]  * structure) + (100.0f - structure) ) / 100.0f ) +
								dmg.basicDamage ["Pierce"] * (((change ["Pierce_to_Cut"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Abrasive"] * (((change ["Abrasive_to_Cut"]  * structure)) / 100.0f );

		dmg.basicDamage ["Pierce"] = dmg.basicDamage ["Blunt"] * (((change ["Blunt_to_Pierce"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Cut"] * (((change ["Cut_to_Pierce"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Pierce"] * (((change ["Pierce_to_Pierce"]  * structure) + (100.0f - structure) ) / 100.0f ) +
								dmg.basicDamage ["Abrasive"] * (((change ["Abrasive_to_Pierce"]  * structure)) / 100.0f );

		dmg.basicDamage ["Abrasive"] = dmg.basicDamage ["Blunt"] * (((change ["Blunt_to_Abrasive"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Cut"] * (((change ["Cut_to_Abrasive"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Pierce"] * (((change ["Pierce_to_Abrasive"]  * structure)) / 100.0f ) +
								dmg.basicDamage ["Abrasive"] * (((change ["Abrasive_to_Abrasive"]  * structure) + (100.0f - structure) ) / 100.0f );

		return dmg;
	}

	void destruct(MechDamage dmg)
	{
		float structureDamage = dmg.basicDamage ["Blunt"] * destruction ["Blunt"] +
								dmg.basicDamage ["Cut"] * destruction ["Cut"] +
								dmg.basicDamage ["Pierce"] * destruction ["Pierce"] +
								dmg.basicDamage ["Abrasive"] * destruction ["Abrasive"];

		if (structure < 0.0f)
			structure = 0.0f;
		structure = structure - structureDamage;
	}

	public MechDamage damage(MechDamage dmg)
	{
		if (structure > 0.0f) {
			MechDamage reductedDmg = reduct (dmg);
			destruct (reductedDmg);
			MechDamage finalDmg = changeDmg (reductedDmg);

			return finalDmg;
		}
		return dmg;
	}

	public void reload(MechArmorItem item)
	{
		change ["Blunt_to_Blunt"] = item.change_Blunt_to_Blunt;
		change ["Cut_to_Blunt"] = item.change_Cut_to_Blunt;
		change ["Pierce_to_Blunt"] = item.change_Pierce_to_Blunt;
		change ["Abrasive_to_Blunt"] = item.change_Abrasive_to_Blunt;

		change ["Blunt_to_Cut"] = item.change_Blunt_to_Cut;
		change ["Cut_to_Cut"] = item.change_Cut_to_Cut;
		change ["Pierce_to_Cut"] = item.change_Pierce_to_Cut;
		change ["Abrasive_to_Cut"] = item.change_Abrasive_to_Cut;

		change ["Blunt_to_Pierce"] = item.change_Blunt_to_Pierce;
		change ["Cut_to_Pierce"] = item.change_Cut_to_Pierce;
		change ["Pierce_to_Pierce"] = item.change_Pierce_to_Pierce;
		change ["Abrasive_to_Pierce"] = item.change_Abrasive_to_Pierce;

		change ["Blunt_to_Abrasive"] = item.change_Blunt_to_Abrasive;
		change ["Cut_to_Abrasive"] = item.change_Cut_to_Abrasive;
		change ["Pierce_to_Abrasive"] = item.change_Pierce_to_Abrasive;
		change ["Abrasive_to_Abrasive"] = item.change_Abrasive_to_Abrasive;

		reduction ["Blunt"] = item.reduction_Blunt;
		reduction ["Cut"] = item.reduction_Cut;
		reduction ["Pierce"] = item.reduction_Pierce;
		reduction ["Abrasive"] = item.reduction_Abrasive;

		destruction ["Blunt"] = item.destruction_Blunt;
		destruction ["Cut"] = item.destruction_Cut;
		destruction ["Pierce"] = item.destruction_Pierce;
		destruction ["Abrasive"] = item.destruction_Abrasive;

		structure = item.structure;
		mass = item.mass;
		name = item.name;
	}

	public void LoadNew(string name)
	{
		MechArmorItem item = MechArmorLoader.getItem(name);
		reload(item);
	}



}

