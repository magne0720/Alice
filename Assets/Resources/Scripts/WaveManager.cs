using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {


    public Emitter emiter;

    int Wavecount = 1;
    public Text Wave;
    public bool isWaving;
    public bool isNextWave;

    // Use this for initialization
    void Start()
    {
        isWaving = false;
        emiter.isPlay = false;
        isNextWave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaving)
        {
            if (emiter.wave.transform.childCount != 0)
            {
                Wavecount = emiter.currentWave + 1;

                Wave.text = ("WAVE  ") + Wavecount.ToString();

                isNextWave = true;
            }
            Debug.Log(Wavecount);
        }
    }

    public void WaveStart()
    {
        isWaving = true;
        emiter.isPlay = true;
    }
    public void WaveStop()
    {
        isWaving = false;
        emiter.isPlay = false;
    }
    public void WaveResset()
    {
        emiter.currentWave = -1;
    }
}
