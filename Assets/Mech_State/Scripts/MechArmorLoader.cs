using UnityEngine;
using System.Collections;

public static class MechArmorLoader
{
	const string ArmorsPath = "MechArmor";
	const string ConstantsPath = "MechArmorMechanicsConstants";

	static MechArmorContainer armorsContainter = MechArmorContainer.Load(ArmorsPath);
	static MechArmorConstantsContainer constantsContainer = MechArmorConstantsContainer.Load(ConstantsPath);

	static public MechArmorConstantsItem getConstants()
	{
		return constantsContainer.constants;
	}

	static public MechArmorItem getItem (string name)
	{
		foreach (MechArmorItem item in armorsContainter.armors) {
			if (item.name == name)
				return item;
		}
		return null;
	}

}

