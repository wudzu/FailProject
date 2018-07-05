using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTable_G  {

    public class PlayerKeys
    {
        public KeyCode Up;
        public KeyCode Down;
        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Jump;
        public KeyCode EnginS_1;
        public KeyCode EnginS_2;
        public KeyCode EnginS_3;
        public KeyCode EnginS_T;
        public KeyCode FireLeft;
        public KeyCode FireRight;
        public KeyCode AltFire;
        public KeyCode Defence;
        public KeyCode Ultimate1;
        public KeyCode Interact;

		public string move_horizontal;
		public string move_vertical;
		public string look_horizontal;
		public string look_vertical;


        /*public PlayerKeys(KeyCode [] KeyList)
        {
            Up          = KeyList[0];
            Down        = KeyList[1];
            Left        = KeyList[2];
            Right       = KeyList[3];
            Jump        = KeyList[4];
            EnginS_1    = KeyList[5];
            EnginS_1    = KeyList[6];
            EnginS_1    = KeyList[7];
            EnginS_T    = KeyList[8];
            FireLeft    = KeyList[9];
            FireRight   = KeyList[10];
            AltFire     = KeyList[11];
            Defence     = KeyList[12];
            Ultimate1   = KeyList[13];
            Interact    = KeyList[14];
        }*/

		public PlayerKeys(int i)
		{
			
			KeyCode [] KeyList = Default_0_List;
			if (i == 1)
				KeyList = Default_1_List;
			
			Up          = KeyList[0];
			Down        = KeyList[1];
			Left        = KeyList[2];
			Right       = KeyList[3];
			Jump        = KeyList[4];
			EnginS_1    = KeyList[5];
			EnginS_1    = KeyList[6];
			EnginS_1    = KeyList[7];
			EnginS_T    = KeyList[8];
			FireLeft    = KeyList[9];
			FireRight   = KeyList[10];
			AltFire     = KeyList[11];
			Defence     = KeyList[12];
			Ultimate1   = KeyList[13];
			Interact    = KeyList[14];

			move_horizontal = Default_Axes[0];
			move_vertical = Default_Axes[1];
			look_horizontal = Default_Axes[2];
			look_vertical = Default_Axes[3];
		}
    }

	static string[] Default_Axes = new string[4] { "Horizontal", "Vertical", "Horizontal2", "Vertical2" };

    static KeyCode[] Default_0_List = new KeyCode[15] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D,
                                                        KeyCode.Space,
                                                        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.F,
                                                        KeyCode.Mouse0, KeyCode.Mouse1,
                                                        KeyCode.LeftControl, KeyCode.LeftShift,
                                                        KeyCode.E, KeyCode.G};

	static KeyCode[] Default_1_List = new KeyCode[15] { KeyCode.JoystickButton0, KeyCode.K, KeyCode.J, KeyCode.L,
														KeyCode.Space,
														KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.F,
														KeyCode.Mouse0, KeyCode.Mouse1,
														KeyCode.LeftControl, KeyCode.LeftShift,
														KeyCode.E, KeyCode.G};


    //public PlayerKeys Default_0 = new PlayerKeys(Default_0_List);
	public PlayerKeys Default_0 = new PlayerKeys(0);

    public PlayerKeys[] Player = new PlayerKeys[4];

	public InputTable_G(int i)
	{
		Default_0 = new PlayerKeys (i);
	}
}
