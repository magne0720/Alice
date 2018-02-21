using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ScoreScript : MonoBehaviour {

    public T_VirtualCharactorScript tc;
    public Text Score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Score.text = ("Score  ") + tc.Vscore.ToString();
    }
}
