using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Propultion_types { Immobile, Wills, Tanktreed, Hovering, Bipedal, Multileg}

public class Propultion_System {

    Dictionary<Terain_types, float> SpeadScale_shadow;
    public Dictionary<Terain_types, float> SpeadScale
    {
        get
        {
            return SpeadScale_shadow;
        }
    }

    public Dictionary<Terain_types, float> Select_Propultion_system(Propultion_types Propultion_system)
    {
        Dictionary<Terain_types, float> Result = new Dictionary<Terain_types, float>();

        switch (Propultion_system)
        {
            case Propultion_types.Immobile:
                Result[Terain_types.Ground] = 0f;
                Result[Terain_types.Road] = 0f;
                Result[Terain_types.Sand] = 0f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0f;
                break;
            case Propultion_types.Wills:
                Result[Terain_types.Ground] = 0.8f;
                Result[Terain_types.Road] = 1f;
                Result[Terain_types.Sand] = 0.6f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0.7f;
                break;
            case Propultion_types.Tanktreed:
                Result[Terain_types.Ground] = 1f;
                Result[Terain_types.Road] = 1f;
                Result[Terain_types.Sand] = 0.8f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0.7f;
                break;
            case Propultion_types.Hovering:
                Result[Terain_types.Ground] = 1f;
                Result[Terain_types.Road] = 1f;
                Result[Terain_types.Sand] = 1f;
                Result[Terain_types.Water] = 1f;
                Result[Terain_types.Acid] = 1f;
                break;
            case Propultion_types.Bipedal:
                Result[Terain_types.Ground] = 0.8f;
                Result[Terain_types.Road] = 1f;
                Result[Terain_types.Sand] = 0.6f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0.6f;
                break;
            case Propultion_types.Multileg:
                Result[Terain_types.Ground] = 0.9f;
                Result[Terain_types.Road] = 1f;
                Result[Terain_types.Sand] = 0.8f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0.8f;
                break;
            default:
                Result[Terain_types.Ground] = 0f;
                Result[Terain_types.Road] = 0f;
                Result[Terain_types.Sand] = 0f;
                Result[Terain_types.Water] = 0f;
                Result[Terain_types.Acid] = 0f;
                break;
        }

        return Result;
    }

    public Propultion_System(Propultion_types selected_propultion)
    {
        SpeadScale_shadow = Select_Propultion_system(selected_propultion);
    }


}
