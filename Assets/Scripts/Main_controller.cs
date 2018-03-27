using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_controller : MonoBehaviour {

    public Text basic;
    public Text help;
    public Text Score;
    bool helpDisplaied = false;

    int ScoreCnt = 0;

    public void AddScore()
    {

        ScoreCnt++;

        Score.text = "Score: " + ScoreCnt.ToString();

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (helpDisplaied)
            {
                basic.enabled = true;
                help.enabled = false;
                helpDisplaied = false;
            }
            else
            {
                basic.enabled = false;
                help.enabled = true;
                helpDisplaied = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
        }

     }
}
