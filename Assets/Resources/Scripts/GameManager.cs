using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Character playerStatus;
    public GameObject title;
    public GameObject waveObj;
    private WaveManager wave;

    public bool isPlay;

    // Use this for initialization
    void Start()
    {
        isPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlay && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
        if (isPlay && playerStatus.HP <= 0)
        {
            GameOver();
        }
    }
    public void GameStart()
    {
        isPlay = true;
        GameObject g = Instantiate(player, new Vector3(0, -4, 0), new Quaternion());
        //プレイヤーとしてみるオブジェクトを登録
        playerStatus = g.GetComponent<Character>();

        //ウェーブ情報を扱えるようにする
        wave = waveObj.GetComponent<WaveManager>();
        wave.WaveStart();

        title.SetActive(false);
    }
    public void GameOver()
    {
        isPlay = false;
        title.SetActive(true);
        wave.WaveStop();
        wave.WaveResset();
    }
}
