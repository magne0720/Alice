using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //プレイヤー
    public GameObject player;
    public GameObject playerObj;
    public  static Character playerStatus;
    //拠点
    public GameObject homebase;
    private GameObject homebaseObj;
    private HomeBase homeStatus;
    //ウェーブ
    public WaveManager wave;
    //強化画面
    public GameObject IntervalUI;
    private CanvasMask grad;
    private bool isIntervalStart;
    private bool isIntervalEnd;

    public N_Result result;
    //強化画面の後ろで時間を視覚的に見せる
    public GameObject IntervalBack;
    private FadeMask back;
    //タイトルやクリア
    public GameObject title;
    public GameObject clear;
    //スコア
    public ScoreDisplay Score;

    //プレイ中かどうか
    public bool isPlay;


    // Use this for initialization
    void Start()
    {
        isPlay = false;
        clear.SetActive(false);

        grad = IntervalUI.GetComponent<CanvasMask>();
        //grad.StartMask(true);
        //IntervalUI.SetActive(false);

        //ウェーブ情報を扱えるようにする
        //wave = waveObj.GetComponent<WaveManager>();
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
        if (player != null)
        {
            Destroy(playerObj);
            Destroy(homebaseObj);
        }
        playerObj = Instantiate(player, new Vector3(0, -1, 0), new Quaternion());
        //プレイヤーとしてみるオブジェクトを登録
        playerStatus = playerObj.GetComponent<Character>();

        homebaseObj = Instantiate(homebase, new Vector3(0, -5, 0), new Quaternion());
        homeStatus = homebaseObj.GetComponent<HomeBase>();
        

        wave.WaveStart();
        result.StopDisp();
        result.Reset();

        title.SetActive(false);
        clear.SetActive(false);
        wave.isGameClear = false;
        isIntervalEnd = true;
    }
    public void GameOver()
    {
        isPlay = false;
        title.SetActive(true);
        wave.WaveStop();
        wave.WaveResset();
        result.StartDisp();
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
        //IntervalUI.SetActive(true);
        grad.StartMask(false);
        Debug.Log("intervalStart");
    }
    void WaveInterval()
    {

    }
    void WaveIntervalEnd()
    {
        //IntervalUI.SetActive(false);
        grad.StartMask(true);
        Debug.Log("intervalEnd");
    }
}
