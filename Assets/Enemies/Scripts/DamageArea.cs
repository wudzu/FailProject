using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour {

    /* Type of damage area */
    public enum DmgAreaType { none, SingleBurst, Deteriorates, StackDOT, Continous };
    public DmgAreaType AreaType = DmgAreaType.none;
    /* parameters for all types of damage area */
    public MechDamage.DamageType TypeOfDamage = MechDamage.DamageType.Spear;
    public float DamageLevel = 15f;
    /* parameters for Deteriorates, StackDOT, Continous */
    public float damage_interval = 2f;
    float Dmg_Timer = 0f;
    /* parameters for Deteriorates */
    float LinearDeteriorationOverTick = 0.2f;
    float MiltiplcalDeteriorationOverTick = 1f;
    /* parameters for StackDOT */
    int stackLimit = 10;

    void ApplyDamage(MechState Target)
    {
        MechDamage temp_BaseDamage = new MechDamage(TypeOfDamage, DamageLevel);
        Target.damage(temp_BaseDamage);
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            MechState mechStateHandle = other.transform.parent.GetComponent<MechState>();
            
            switch (AreaType)
            {
                case DmgAreaType.SingleBurst:
                case DmgAreaType.Continous:
                    Dmg_Timer = damage_interval;
                    ApplyDamage(mechStateHandle);
                    break;
                default:
                    Debug.Log(" area type not handled (1)");
                    break;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            MechState mechStateHandle = other.transform.parent.GetComponent<MechState>();

            switch (AreaType)
            {
                case DmgAreaType.SingleBurst:
                    /* do nothing */
                    break;
                case DmgAreaType.Continous:
                    if(Dmg_Timer > 0f)
                    {
                        Dmg_Timer -= Time.deltaTime;
                    }
                    else
                    {
                        Dmg_Timer = damage_interval;
                        ApplyDamage(mechStateHandle);
                    }
                    break;
                default:
                    Debug.Log(" area type not handled (2)");
                    break;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        /* nothing needed for now */
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
