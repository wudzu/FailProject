using UnityEngine;
using System.Collections;

public class MechDamage : MonoBehaviour
{
	var basicDamage   = new Dictionary<string, float>();


	// Use this for initialization
	void Start ()
	{
		basicDamage ["Blunt"] = 0.0;
		basicDamage ["Cut"] = 0.0;
		basicDamage ["Pierce"] = 15.0;
		basicDamage ["Abrasive"] = 0.0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

