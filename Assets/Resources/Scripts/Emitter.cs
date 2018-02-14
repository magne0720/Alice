using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    public GameObject[] waves;
    public int currentWave;
    public GameObject wave;
    public bool isWaving;

    // Use this for initialization
    void Start()
    {
        /*
        if (waves.Length == 0)
        {
            return;
        }

        while (true)
        {
            while (!isPlay)
            {
                return;
                //yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            wave = (GameObject)Instantiate(waves[currentWave], waves[currentWave].transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                return;
                //yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
        */

        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ウェーブ未設定
        if (waves.Length == 0)
        {
            return;
        }
        if (isWaving)
        {
            if (wave.transform.childCount == 0)
            {
                // Waveの削除
                Destroy(wave);

                isWaving = false;
            }
        }
        // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
        //if (waves.Length <= ++currentWave)
        //{
        //    currentWave = 0;
        //}
    }
    public void WaveInstance()
    {
        if (currentWave >= waves.Length)
        {
            Debug.Log("wave end");
            return;
        }

        // Waveを作成する
        wave = (GameObject)Instantiate(waves[currentWave], waves[currentWave].transform.position, Quaternion.identity);

        // WaveをEmitterの子要素にする
        wave.transform.parent = transform;

        currentWave++;
        isWaving = true;
    }
}
