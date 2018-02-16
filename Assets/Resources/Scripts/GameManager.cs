using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //プレイヤー
    public GameObject player;
    private Character playerStatus;
    //拠点
    public GameObject homebase;
    private HomeBase homeStatus;
    //ウェーブ
    public GameObject waveObj;
    private WaveManager wave;
    //強化画面
    public GameObject IntervalUI;
    private FadeMask grad;
    private bool isIntervalStart;
    private bool isIntervalEnd;
    //タイトルやクリア
    public GameObject title;
    public GameObject clear;

    //プレイ中かどうか
    public bool isPlay;


    // Use this for initialization
    void Start()
    {
        isPlay = false;
        clear.SetActive(false);

        grad = IntervalUI.GetComponent<FadeMask>();
        IntervalUI.SetActive(false);

        //ウェーブ情報を扱えるようにする
        wave = waveObj.GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlay && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
            return;
        }
        if (isPlay)
        {
            if (playerStatus.HP <= 0||homeStatus.HP<=0)
            {
                GameOver();
            }
            if (!wave.isWaving)
            {
                if (!isIntervalStart)
                {
                    isIntervalStart = true;
                    isIntervalEnd = false;
                    WaveIntervalStart();
                }
            }
            else
            {
                if (!isIntervalEnd)
                {
                    isIntervalStart = false;
                    isIntervalEnd = true;
                    WaveIntervalEnd();
                }
            }
        }
        if (wave.isGameClear)
        {
            GameClear();
        }
    }
    public void GameStart()
    {
        isPlay = true;
        GameObject playerObj = Instantiate(player, new Vector3(0, -4, 0), new Quaternion());
        //プレイヤーとしてみるオブジェクトを登録
        playerStatus = playerObj.GetComponent<Character>();

        GameObject homeObj = Instantiate(homebase, new Vector3(0, 0, 0), new Quaternion());
        homeStatus = homeObj.GetComponent<HomeBase>();

        wave.WaveStart();

        title.SetActive(false);
        clear.SetActive(false);
    }
    public void GameOver()
    {
        isPlay = false;
        title.SetActive(true);
        wave.WaveStop();
        wave.WaveResset();
    }
    public void GameClear()
    {
        isPlay = false;
        clear.SetActive(true);
        wave.WaveStop();
        wave.WaveResset();
    }

    void WaveIntervalStart()
    {
        IntervalUI.SetActive(true);
        grad.StartMask(false);
        Debug.Log("intervalStart");
    }
    void WaveInterval()
    {

    }
    void WaveIntervalEnd()
    {
        IntervalUI.SetActive(false);
        grad.StartMask(true);
        Debug.Log("intervalEnd");
    }
}
