using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechState : MonoBehaviour
{
	MechCore core = new MechCore();
	List<MechArmor> armor = new List<MechArmor>();


	void damage (MechDamage dmg)
	{
		foreach (MechArmor arm in armor)
		{
			dmg = arm.damage(dmg);
		}

		core.damage(dmg);
		/*
		if (core.ifStun()) {
			//Stun mech
		}

		if (core.ifDead() ) {
			//Kill mech
		}*/
	}

	// Use this for initialization
	void Start ()
	{
		MechArmor a = new MechArmor();
		MechArmor b = new MechArmor();
		MechArmor c = new MechArmor();
		a.LoadNew(A_Type.MetalHard);
		b.LoadNew(A_Type.MetalSoft);
		c.LoadNew(A_Type.Ammortization);

		armor.Add(a);
		armor.Add(b);
		armor.Add(c);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

