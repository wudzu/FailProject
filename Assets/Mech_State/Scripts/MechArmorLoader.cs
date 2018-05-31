using UnityEngine;
using System.Collections;

public static class MechArmorLoader
{
	const string path = "MechArmor";

	static MechArmorContainer armorsContainter = MechArmorContainer.Load (path);

	static public MechArmorItem getItem (string name)
	{
		foreach (MechArmorItem item in armorsContainter.armors) {
			if (item.name == name)
				return item;
		}
		return null;
	}

}

