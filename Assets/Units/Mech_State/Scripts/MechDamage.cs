using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechDamage
{
    public enum DamageType { none, Hammer, Saber, Spear, Sow, ALL };
    public Dictionary<string, float> basicDamage   = new Dictionary<string, float>();

    public MechDamage(DamageType WeponType, float DmgLevel)
    {
        basicDamage["Blunt"] = 0.0f;
        basicDamage["Cut"] = 0.0f;
        basicDamage["Pierce"] = 0.0f;
        basicDamage["Abrasive"] = 0.0f;

        switch (WeponType)
        {
            case DamageType.Hammer:
                basicDamage["Blunt"] = 1.0f * DmgLevel;
                break;
            case DamageType.Saber:
                basicDamage["Cut"] = 1.0f * DmgLevel;
                break;
            case DamageType.Spear:
                basicDamage["Pierce"] = 1.0f * DmgLevel;
                break;
            case DamageType.Sow:
                basicDamage["Abrasive"] = 1.0f * DmgLevel;
                break;
            case DamageType.ALL:
                basicDamage["Blunt"] = 1.0f * DmgLevel;
                basicDamage["Cut"] = 1.0f * DmgLevel;
                basicDamage["Pierce"] = 1.0f * DmgLevel;
                basicDamage["Abrasive"] = 1.0f * DmgLevel;
                break;
            default:
                Debug.Log("MechDamage: WeponType not handled");
                break;
        }

    }

    public MechDamage( float Dmg_Blunt, float Dmg_Cut, float Dmg_Pierce, float Dmg_Abrasive)
    {
        basicDamage["Blunt"] = Dmg_Blunt;
        basicDamage["Cut"] = Dmg_Cut;
        basicDamage["Pierce"] = Dmg_Pierce;
        basicDamage["Abrasive"] = Dmg_Abrasive;
    }

    //	// Use this for initialization
    //	void Start ()
    //	{
    //		basicDamage ["Blunt"] = 0.0f;
    //		basicDamage ["Cut"] = 0.0f;
    //		basicDamage ["Pierce"] = 15.0f;
    //		basicDamage ["Abrasive"] = 0.0f;
    //	}
    //	
    //	// Update is called once per frame
    //	void Update ()
    //	{
    //	
    //	}
}

