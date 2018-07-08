using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class MechArmorConstantsItem
{

	[XmlElement("CoreStructure")]
	public float CoreStructure;

	[XmlElement("CoreEnergy")]
	public float CoreEnergy;


	[XmlElement("energyMove")]
	public float energyMove;

	[XmlElement("CoreRegeneration")]
	public float CoreRegeneration;

	[XmlElement("BluntEnergyDamage")]
	public float BluntEnergyDamage;

	[XmlElement("CutEnergyDamage")]
	public float CutEnergyDamage;

	[XmlElement("PierceEnergyDamage")]
	public float PierceEnergyDamage;

	[XmlElement("AbrasiveEnergyDamage")]
	public float AbrasiveEnergyDamage;

	[XmlElement("EnergyDamageThreshold")]
	public float EnergyDamageThreshold;

	[XmlElement("EnergyDamageRate")]
	public float EnergyDamageRate;

	[XmlElement("EnergyLeakRate")]
	public float EnergyLeakRate;
}

