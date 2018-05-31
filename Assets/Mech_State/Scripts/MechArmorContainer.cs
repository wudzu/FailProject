using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class MechArmorContainer 
{
	[XmlArray("Armors")]
	[XmlArrayItem("MechArmorItem")]
	public List<MechArmorItem> armors = new List<MechArmorItem>();

	public static MechArmorContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(MechArmorContainer));

		StringReader reader = new StringReader(_xml.text);

		MechArmorContainer armors = serializer.Deserialize(reader) as MechArmorContainer;

		reader.Close();

		return armors;
	}

}

