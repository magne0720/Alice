using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour {

    public Text Wave;
    int WaveCount = 1;

	// Use this for initialization
	void Start () {
        Wave.text = ("WAVE  ") + WaveCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
