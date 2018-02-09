using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_WaveScript : MonoBehaviour {

    public T_EmmiterScript Emmiter;

    int Wavecount = 1;
    public Text Wave;

    // Use this for initialization
    void Start()
    {


    }
	
	// Update is called once per frame
	void Update () {
        if (Emmiter.wave.transform.childCount != 0)
        {
            Wavecount = Emmiter.currentWave + 1;

            Wave.text = ("WAVE  ") + Wavecount.ToString();
        }
        Debug.Log(Wavecount);
	}
    void test()
    {

    }
}
