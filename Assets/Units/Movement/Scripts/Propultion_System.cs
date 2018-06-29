using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Propultion_types { Immobile, Wills, Tanktreed, Hovering, Bipedal, Multileg, TestOnly, TestPathfinding}

public class Propultion_System {

    Dictionary<Terain_types, int> SpeadScale_shadow;
    public Dictionary<Terain_types, int> SpeadScale
    {
        get
        {
            return SpeadScale_shadow;
        }
    }

    public Dictionary<Terain_types, int> Select_Propultion_system(Propultion_types Propultion_system)
    {
        Dictionary<Terain_types, int> Result = new Dictionary<Terain_types, int>();

        switch (Propultion_system)
        {
            case Propultion_types.Immobile:
                Result[Terain_types.Ground] = 0;
                Result[Terain_types.Road] = 0;
                Result[Terain_types.Sand] = 0;
                Result[Terain_types.Water] = 0;
                Result[Terain_types.Acid] = 0;
                break;
            case Propultion_types.Wills:
                Result[Terain_types.Ground] = 80;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 60;
                Result[Terain_types.Water] = 1;
                Result[Terain_types.Acid] = 70;
                break;
            case Propultion_types.Tanktreed:
                Result[Terain_types.Ground] = 100;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 80;
                Result[Terain_types.Water] = 1;
                Result[Terain_types.Acid] = 70;
                break;
            case Propultion_types.Hovering:
                Result[Terain_types.Ground] = 100;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 100;
                Result[Terain_types.Water] = 100;
                Result[Terain_types.Acid] = 100;
                break;
            case Propultion_types.Bipedal:
                Result[Terain_types.Ground] = 80;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 60;
                Result[Terain_types.Water] = 1;
                Result[Terain_types.Acid] = 60;
                break;
            case Propultion_types.Multileg:
                Result[Terain_types.Ground] = 90;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 80;
                Result[Terain_types.Water] = 1;
                Result[Terain_types.Acid] = 80;
                break;
            case Propultion_types.TestOnly:
                Result[Terain_types.Ground] = 80;
                Result[Terain_types.Road] = 100;
                Result[Terain_types.Sand] = 60;
                Result[Terain_types.Water] = 30;
                Result[Terain_types.Acid] = 150;
                break;
			case Propultion_types.TestPathfinding:
				Result[Terain_types.Ground] = 1;
				Result[Terain_types.Road] = 0;
				Result[Terain_types.Sand] = 2;
				Result[Terain_types.Water] = 5;
				Result[Terain_types.Acid] = 7;
				break;
            default:
                Result[Terain_types.Ground] = 1;
                Result[Terain_types.Road] = 1;
                Result[Terain_types.Sand] = 1;
                Result[Terain_types.Water] = 1;
                Result[Terain_types.Acid] = 1;
                break;
        }

        return Result;
    }

    public Propultion_System(Propultion_types selected_propultion)
    {
        SpeadScale_shadow = Select_Propultion_system(selected_propultion);
    }


}
