using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_Ctrl : MonoBehaviour {

    public enum W_Type { none, Spear, Sword, Axe, Hammer };

    public W_Type Wepon = W_Type.none;
    public MechDamage.DamageType TypeOfDamage = MechDamage.DamageType.none;
    public float DamageLevel = 0f;

    public Rigidbody Player_body;

    Vector3 StartingPosition;
    bool isInAttac = false;
    int AttacPhase = 0;
    float AttacTimer = 0f;

    float StartPush = 10f;
    float ImpactPush = 300f;

    public void Wepon_Colider_Hit(int Collider_Idx, Collision Col = null)
    {
		if (Col.gameObject.CompareTag("Enemy") || Col.gameObject.CompareTag("Player"))
        {
            if(AttacPhase == 3)
            {
                /* Apply damage */
                MechState targetMechState = Col.transform.GetComponent<MechState>();
                if (targetMechState)
                {
                    float damageRescaled = DamageLevel * (0.4f + (0.1f - AttacTimer) * 5f);

                    MechDamage temp_BaseDamage = new MechDamage(TypeOfDamage, damageRescaled);
                    targetMechState.damage(temp_BaseDamage);
                }
                else
                {
                    Debug.Log("Wepon_Colider_Hit: target has no mech state ");
                }

                
                /* apply hit phisics */
                float Force = ImpactPush * (0.11f - AttacTimer) * 10f;
                float angle = transform.rotation.eulerAngles.y / 180f *Mathf.PI;
                Vector3 direction = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));

                Col.rigidbody.AddForce(direction * Force, ForceMode.Impulse);
                
                /* ... and recoil */
                Player_body.AddForce(-direction * Force * 0.2f, ForceMode.Impulse);

                /* go to next state */
                AttacPhase = 2;
            }
        }
        if (Col.gameObject.CompareTag("Environment"))
        {

            if (AttacPhase == 3)
            {
                float Force = ImpactPush * (0.11f - AttacTimer) * 10f;
                float angle = transform.rotation.eulerAngles.y / 180f * Mathf.PI;
                Vector3 direction = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));


                Player_body.AddForce(-direction * Force * 0.4f, ForceMode.Impulse);
                AttacPhase = 2;
            }
        }

    }

    public void Attak( bool withAltActive)
    {
        switch (Wepon)
        {
            case W_Type.Spear:

                if( !isInAttac)
                {
                    AttacPhase = 3;
                    AttacTimer = 0.1f;

                    Player_body.AddForceAtPosition( Vector3.up* StartPush, transform.position, ForceMode.Impulse);
                    isInAttac = true;

                    
                }

                break;
            default: // do noting
                break;
        }
    }

    public void RefreshAttak(bool withAltActive)
    {
        switch (Wepon)
        {
            case W_Type.Spear:

                break;
            default: // do noting
                break;
        }

    }
    
    void AmimatePush()
    {
        Vector3 MaxExt = new Vector3(0f, 0f, 1f);

        AttacTimer -= Time.deltaTime;

        switch (AttacPhase)
        {
            case 3:
                transform.localPosition = StartingPosition + 10f*(0.1f - AttacTimer) * MaxExt;
                break;
            case 2:


                AttacTimer = (1f - 10f * AttacTimer) * 0.9f;
                AttacPhase = 1;
                break;
            case 1:
                transform.localPosition = StartingPosition + MaxExt *(AttacTimer) ;
                break;
        }
        if(AttacTimer < 0)
        {

            switch (AttacPhase)
            {
                case 3:
                    AttacPhase = 1;
                    AttacTimer = 1f;
                    break;
                case 2:
                    AttacPhase = 1;
                    AttacTimer = 0.05f;
                    break;
                case 1:
                    AttacPhase = 0;
                    AttacTimer = 0;
                    isInAttac = false;
                    break;
            }
        }

    }

    // Use this for initialization
    void Start () {
        StartingPosition = transform.localPosition;
        
        // [TO DO] might cause problems in PvP modes
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Players"), LayerMask.NameToLayer("PlayerWepon"));

    }
	
	// Update is called once per frame
	void Update () {

        if (isInAttac)
        {
            AmimatePush();
        }

    }
}
