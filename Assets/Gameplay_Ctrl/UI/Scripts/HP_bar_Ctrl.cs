using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_bar_Ctrl : MonoBehaviour {

    /* display settings */
    public Vector2 Psition_Offset = Vector2.zero;
    public Vector2 Display_Scale = new Vector2(0.6f, 0.8f);

    public GameObject Background_Bar;
    public GameObject HP_level_disp;
    public GameObject Armor_disp_prefab;

    const float Max_wdth = 100f;
    const float Block_gap = 2f;

    List<GameObject> Armor_list = new List<GameObject>();

    void Change_armor_Layers(int Layer_Count)
    {
        foreach(GameObject SingleArmor in Armor_list)
        {
            Destroy(SingleArmor);
        }
        Armor_list.Clear();


        float width = (Max_wdth - Block_gap) / (float)Layer_Count;
        float gap = Block_gap / (float)Layer_Count;

        for (int Idx = 0; Idx < Layer_Count; Idx++)
        {
            GameObject New_armor = Instantiate(Armor_disp_prefab, Background_Bar.transform);
            RectTransform Armor_transform = New_armor.transform as RectTransform;

            Armor_transform.sizeDelta = new Vector2(width, Armor_transform.sizeDelta.y);

            float New_Position = Armor_transform.localPosition.x + ((float)Idx) * (width + gap);
            Armor_transform.localPosition = new Vector3(New_Position, Armor_transform.localPosition.y, Armor_transform.localPosition.z);

            Armor_list.Add(New_armor);
        }
        
     }

    public void Update_display_Levels(float HP_percent, List<float> Armors_percentage)
    {
        RectTransform HP_transform =  HP_level_disp.transform as RectTransform;

        HP_transform.sizeDelta = new Vector2(HP_percent,  HP_transform.sizeDelta.y);


        int Arm_layers = Armors_percentage.Count;

        if (Armor_list.Count != Arm_layers)
            Change_armor_Layers(Arm_layers);

        float BlockScaler = (Max_wdth / (Max_wdth* (Arm_layers) + Block_gap * (Arm_layers-1)));

        for (int Idx=0; Idx < Arm_layers; Idx++)
        {
            RectTransform Armor_transform = Armor_list[Idx].transform as RectTransform;
            Armor_transform.sizeDelta = new Vector2(Armors_percentage[Idx]* BlockScaler, Armor_transform.sizeDelta.y);
        }


    }

    void update_HP_disp()
    {
        Background_Bar.transform.localPosition = new Vector3(Psition_Offset.x, Psition_Offset.y, 1f);
        Background_Bar.transform.localScale = new Vector3(Display_Scale.x, Display_Scale.y, 1f);
    }

    public void Chsange_display_position_offset(float Vertical, float Horizontal)
    {
        Psition_Offset = new Vector2(Horizontal, Vertical);
        update_HP_disp();
    }
    public void Chsange_display_Scale(float Height, float Width)
    {
        Display_Scale = new Vector2(Width, Height);
        update_HP_disp();
    }

    public void Update_Position( GameObject FollowedObject)
    {
        Vector2 Position_on = Camera.main.WorldToScreenPoint(FollowedObject.transform.position);
        

        RectTransform Transf = transform as RectTransform;

        Transf.position = Position_on;
    }

	// Use this for initialization
	void Start () {
        /*
        List<float> tempList = new List<float>();
        tempList.Add(100f);
        tempList.Add(100f);
        tempList.Add(50f);


        Update_display_Levels( 80 , tempList);
        */
        Chsange_display_position_offset(20, 0);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
