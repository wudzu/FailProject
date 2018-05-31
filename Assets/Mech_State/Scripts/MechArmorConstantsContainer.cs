using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class MechArmorConstantsContainer 
{
	[XmlElement("Constants")]
	public MechArmorConstantsItem constants = new MechArmorConstantsItem();

	public static MechArmorConstantsContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(MechArmorConstantsContainer));

		StringReader reader = new StringReader(_xml.text);

		MechArmorConstantsContainer constants = serializer.Deserialize(reader) as MechArmorConstantsContainer;

		reader.Close();

		return constants;
	}

}

