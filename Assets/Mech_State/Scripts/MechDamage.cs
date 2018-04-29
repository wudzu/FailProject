using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechDamage : MonoBehaviour
{
	public Dictionary<string, float> basicDamage   = new Dictionary<string, float>();


	// Use this for initialization
	void Start ()
	{
		basicDamage ["Blunt"] = 0.0f;
		basicDamage ["Cut"] = 0.0f;
		basicDamage ["Pierce"] = 15.0f;
		basicDamage ["Abrasive"] = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

