using UnityEngine;
using System.Collections;

public class MechCore : MonoBehaviour
{

	float structure = 100.0f; //HP
	float energy = 100.0f;
	float regeneration = 5.0f;

	public void damage(MechDamage dmg)
	{
		energy -= (dmg.basicDamage ["Blunt"] * 0.25f + dmg.basicDamage ["Cut"] * 0.5f + dmg.basicDamage ["Pierce"] * 0.75f + dmg.basicDamage ["Abrasive"] * 0.5f);
		structure -= (dmg.basicDamage ["Blunt"] * 0.75f + dmg.basicDamage ["Cut"] * 0.5f + dmg.basicDamage ["Pierce"] * 0.25f + dmg.basicDamage ["Abrasive"] * 0.5f);
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

    // Use this for initialization
    void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		energy = energy + regeneration;
		if (energy > structure)
			energy = structure;
	}
}

