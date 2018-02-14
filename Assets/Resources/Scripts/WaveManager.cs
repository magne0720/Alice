using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {


    public Emitter emiter;

    int Wavecount = 1;
    public Text Wave;
    //private bool isWaving;

    public float WaitTime;
    private float timer;
    public bool isPlay;
    public bool isGameClear;

    // Use this for initialization
    void Start()
    {
        //isWaving = false;

        isGameClear = false;
        timer = 0;
        WaitTime = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (emiter.isGameClear)
        {
            isGameClear = true;
        }
        if (!isPlay)
        {
            return;
        }
        //ウェーブ中
        if (emiter.isWaving)
        {
            //敵がまだいるなら
            if (emiter.wave.transform.childCount != 0)
            {
                Wavecount = emiter.currentWave + 1;

                Wave.text = ("WAVE  ") + Wavecount.ToString();
            }
            Debug.Log(Wavecount);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > WaitTime)
            {
                timer = 0;
                emiter.WaveInstance();
                //isWaving = true;
            }
            int time = (int)(WaitTime - timer);
            Wave.text = ("次のWAVEまで  ") + time.ToString()+("秒");
        }
    }

    public void WaveStart()
    {
        isPlay = true;
        emiter.WaveInstance();
    }
    public void WaveStop()
    {
        isPlay = false;
    }
    public void WaveResset()
    {
        emiter.currentWave = 0;
    }
}
