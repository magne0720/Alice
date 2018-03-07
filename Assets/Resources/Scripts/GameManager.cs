using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲーム上の上限
    public const int GAMEPLAYER_MAXHP = 500;
    public const float GAMEPLAYER_MAXPOW = 10.0f;
    public const float GAMEPLAYER_MAXDELAY = 2.0f;

    //プレイヤー
    public GameObject player;
    private GameObject playerObj;
    public  static Character playerStatus;
    //拠点
    public GameObject homebase;
    private GameObject homebaseObj;
    private HomeBase homeStatus;
    //ウェーブ
    public WaveManager wave;
    //強化画面
    public GameObject IntervalUI;
    List<ContentDispacher> CDItems;
    private CanvasMask grad;
    private bool isIntervalStart;
    private bool isIntervalEnd;

    //矢印UI
    private GameObject ShotTargetUIObj;

    //リザルト
    public N_Result result;
    //タイトルやクリア
    public GameObject title;
    public GameObject clear;
    //スコア
    public ScoreDisplay Score;

    //プレイ中かどうか
    public bool isPlay;

    public static int KilledValue;
    private GameObject virtualPlayer;
    private float timer = 0;

    // Use this for initialization
    void Awake()
    {
        isPlay = false;
        clear.SetActive(false);

        grad = IntervalUI.GetComponent<CanvasMask>();
        CDItems = new List<ContentDispacher>();
        foreach(ContentDispacher c in IntervalUI.GetComponentsInChildren<ContentDispacher>())
        {
            CDItems.Add(c);
        }
        //grad.StartMask(true);
        //IntervalUI.SetActive(false);

        //ウェーブ情報を扱えるようにする
        //wave = waveObj.GetComponent<WaveManager>();

        //仮想プレイヤーの生成
        virtualPlayer = new GameObject();
        virtualPlayer.transform.name = "virtual";
        virtualPlayer.AddComponent<VirtualCharactor>();

        ShotTargetUIObj = GameObject.Find("ShotUI");
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
            if (playerStatus.HP <= 0 || homeStatus.HP <= 0)
            {
                GameOver();
            }
            if (!wave.isWaving)
            {
                if (!isIntervalStart)
                {
                    if (timer < 4.0f)
                    {
                        timer += Time.deltaTime;
                    }
                    else
                    {
                        isIntervalStart = true;
                        isIntervalEnd = false;
                        WaveIntervalStart();
                    }
                }
            }
            else
            {
                if (!isIntervalEnd)
                {
                    timer = 0;
                    isIntervalStart = false;
                    isIntervalEnd = true;
                    WaveIntervalEnd();
                }
            }
            if (wave.isGameClear)
            {
                GameClear();
            }
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

        KilledValue = 0;

        wave.WaveStart();
        result.StopDisp();
        result.Reset();

        Score.player = playerStatus;

        //Bullet購入情報の初期化
        foreach(ContentDispacher c in CDItems)
        {
            c.ItemResset();
        }


        title.SetActive(false);
        clear.SetActive(false);
        wave.isGameClear = false;
        isIntervalEnd = true;
    }
    public void GameOver()
    {
        isPlay = false;
       // title.SetActive(true);
        
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
        result.StartDisp();
    }

    void WaveIntervalStart()
    {
        virtualPlayer.GetComponent<VirtualCharactor>().SetPlayer(playerStatus);

        foreach(WeaponButton w in IntervalUI.GetComponentsInChildren<WeaponButton>())
        {
            w.Player = playerStatus;
        }
        //foreach(ContentDispacher c in CDItems)
        //{
        //    c.ResetPosition();
        //}

        IntervalUI.SetActive(true);
        grad.StartMask(false);
        Debug.Log("intervalStart");
        playerStatus.SetLock(true);
       homeStatus.SetLock(true);
    }
    void WaveInterval()
    {

    }
    void WaveIntervalEnd()
    {
        grad.StartMask(true);
        Debug.Log("intervalEnd");

        playerStatus.SetLock(false);
        homeStatus.SetLock(false);
    }
}
