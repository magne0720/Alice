using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    const float SET_WAVE_TIME = 3.0f;

    public Emitter emiter;

    int Wavecount = 1;
    //現在のウェーブ表示
    public Text Wave;
    //ウェーブ変更の表示
    public AlertDisplay Alert;

    //private bool isWaving;

    public float WaitTime;
    private float timer;
    public bool isPlay;
    public bool isWaving;
    public bool isGameClear;

    // Use this for initialization
    void Start()
    {
        //isWaving = false;

        isGameClear = false;
        timer = 0;
        //WaitTime = 60.0f;
        isWaving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグコード
        if (Input.GetKeyDown(KeyCode.N))
        {
            timer = 60;
        }
        if (emiter.currentWave >= emiter.waves.Length)
        {
            isGameClear = true;
            return;
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
                Wavecount = emiter.currentWave;

                Wave.text = ("WAVE  ") + Wavecount.ToString();
            }
            else
            {
                isWaving = false;
            }
            Debug.Log(Wavecount);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > WaitTime)
            {
                isWaving = true;
                timer = 0;
                Alert.Play(SET_WAVE_TIME-1);
                emiter.SetInstanceTime(SET_WAVE_TIME);
            }
            int time = (int)(WaitTime - timer);
            Wave.text = ("\t\t\t\t次のWAVEまで  ") + time.ToString()+("秒");
        }
    }

    public void WaveStart()
    {
        isPlay = true;
        isWaving = true;
        Alert.Play(SET_WAVE_TIME-1);
        emiter.SetInstanceTime(SET_WAVE_TIME);
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
