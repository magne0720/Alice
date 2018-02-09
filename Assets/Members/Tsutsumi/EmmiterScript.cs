using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmiterScript : MonoBehaviour {

    public GameObject[] waves;
    public int currentWave;
    public GameObject wave;

    // Use this for initialization
    IEnumerator Start()
    {
        if (waves.Length == 0)
        {
            yield break;
        }

        while (true)
        {

            // Waveを作成する
            wave = (GameObject)Instantiate(waves[currentWave], waves[currentWave].transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
