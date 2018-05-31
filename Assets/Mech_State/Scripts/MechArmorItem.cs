using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class MechArmorItem 
{
	[XmlAttribute("name")]
	public string name;

	[XmlElement("structure")]
	public float structure;
	[XmlElement("mass")]
	public float mass;

	[XmlElement("change_Blunt_to_Blunt")]
	public float change_Blunt_to_Blunt;
	[XmlElement("change_Cut_to_Blunt")]
	public float change_Cut_to_Blunt;
	[XmlElement("change_Pierce_to_Blunt")]
	public float change_Pierce_to_Blunt;
	[XmlElement("change_Abrasive_to_Blunt")] 
	public float change_Abrasive_to_Blunt;

	[XmlElement("change_Blunt_to_Cut")]
	public float change_Blunt_to_Cut;
	[XmlElement("change_Cut_to_Cut")] 
	public float change_Cut_to_Cut;
	[XmlElement("change_Pierce_to_Cut")] 
	public float change_Pierce_to_Cut;
	[XmlElement("change_Abrasive_to_Cut")] 
	public float change_Abrasive_to_Cut;

	[XmlElement("change_Blunt_to_Pierce")] 
	public float change_Blunt_to_Pierce;
	[XmlElement("change_Cut_to_Pierce")] 
	public float change_Cut_to_Pierce;
	[XmlElement("change_Pierce_to_Pierce")] 
	public float change_Pierce_to_Pierce;
	[XmlElement("change_Abrasive_to_Pierce")]
	public float change_Abrasive_to_Pierce;

	[XmlElement("change_Blunt_to_Abrasive")]
	public float change_Blunt_to_Abrasive;
	[XmlElement("change_Cut_to_Abrasive")] 
	public float change_Cut_to_Abrasive;
	[XmlElement("change_Pierce_to_Abrasive")] 
	public float change_Pierce_to_Abrasive;
	[XmlElement("change_Abrasive_to_Abrasive")] 
	public float change_Abrasive_to_Abrasive;

	[XmlElement("reduction_Blunt")]
	public float reduction_Blunt;
	[XmlElement("reduction_Cut")] 
	public float reduction_Cut;
	[XmlElement("reduction_Pierce")] 
	public float reduction_Pierce;
	[XmlElement("reduction_Abrasive")] 
	public float reduction_Abrasive;

	[XmlElement("destruction_Blunt")]
	public float destruction_Blunt;
	[XmlElement("destruction_Cut")]
	public float destruction_Cut;
	[XmlElement("destruction_Pierce")]
	public float destruction_Pierce;
	[XmlElement("destruction_Abrasive")]
	public float destruction_Abrasive;
}

