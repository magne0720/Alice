using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {


    public Emitter emiter;

    int Wavecount = 1;
    public Text Wave;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (emiter.wave.transform.childCount != 0)
        {
            Wavecount = emiter.currentWave + 1;

            Wave.text = ("WAVE  ") + Wavecount.ToString();
        }
        Debug.Log(Wavecount);
    }
    void test()
    {

    }
}
