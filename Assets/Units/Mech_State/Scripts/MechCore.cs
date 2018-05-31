using UnityEngine;
using System.Collections;

public class MechCore 
{

	float structure;
	float energy;
	float maxEnergy;
	float regeneration;
	float energyLeak;
	float energyThreshold;
	float energyDamage;

	public void start()
	{
		structure = MechArmorLoader.getConstants().CoreStructure;
		energy = MechArmorLoader.getConstants().CoreEnergy;
		maxEnergy = MechArmorLoader.getConstants().CoreEnergy;
		regeneration = MechArmorLoader.getConstants().CoreRegeneration;
		energyLeak = MechArmorLoader.getConstants().EnergyLeakRate;
		energyThreshold = MechArmorLoader.getConstants().EnergyDamageThreshold * MechArmorLoader.getConstants().CoreEnergy;
		energyDamage = MechArmorLoader.getConstants().EnergyDamageRate;
	}

	public void damage(MechDamage dmg)
	{
		energy -= dmg.basicDamage ["Blunt"] * MechArmorLoader.getConstants().BluntEnergyDamage;
		energy -= dmg.basicDamage ["Cut"] * MechArmorLoader.getConstants().CutEnergyDamage;
		energy -= dmg.basicDamage ["Pierce"] * MechArmorLoader.getConstants().PierceEnergyDamage;
		energy -= dmg.basicDamage ["Abrasive"] * MechArmorLoader.getConstants().AbrasiveEnergyDamage;

		structure -= dmg.basicDamage ["Blunt"] * (1.0f - MechArmorLoader.getConstants().BluntEnergyDamage);
		structure -= dmg.basicDamage ["Cut"] * (1.0f - MechArmorLoader.getConstants().CutEnergyDamage);
		structure -= dmg.basicDamage ["Pierce"] * (1.0f - MechArmorLoader.getConstants().PierceEnergyDamage);
		structure -= dmg.basicDamage ["Abrasive"] * (1.0f - MechArmorLoader.getConstants().AbrasiveEnergyDamage);
	}

	public bool ifDead()
	{
		return (structure <= 0.0f);
	}

	public bool ifStun()
	{
		if (energy < 0.0f) {
			energy = 0;
			return true;
		}
		return false;
	}

    public float Get_HP_Level()
    {
        return structure;
    }

    public float Get_Energy_Level()
    {
        return energy;
    }


    // Update is called once per frame
    public void CoreUpdate (float TimeDif)
	{
		if (energy < maxEnergy) {
			energy = energy + regeneration* TimeDif;
			if (energy > structure)
				energy = structure;
		}
		// Little too much energy does nothing, it leaks slowly,
		// Much too much energy destorys core
		else if (energy > maxEnergy) {
			energy -= energyLeak * TimeDif;
			if (energy <= maxEnergy){
				energy = maxEnergy;
			} else if (energy >= energyThreshold) {
				structure -= energyDamage * (energy - maxEnergy) * TimeDif;
			}
		}
	}
}

