using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public int ControlType;
    Vector3 lastTarget;
    bool isTouch;
    bool isRightTouch, isLeftTouch;

    //玉射出の方向
    Vector3 mouseStartShotPos = new Vector3();
    Vector3 mouseDragShotPos = new Vector3();
    Vector3 mouseStartMovePos = new Vector3();
    Vector3 mouseDragMovePos = new Vector3();

    public void Initialize()
    {
        HP = GameManager.GAMEPLAYER_MAXHP;
        base.Start();
        timer = 0;
        currentBullet = 0;
        gameObject.layer = 8;//Player
        gameObject.tag = "Player";
        gameObject.name = "Player";

        SetHPVer();
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputMass();

        //if (HP <= 0)
        //{
        //    // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
        //    FindObjectOfType<N_GameManager>().GameOver();
        //}
        if (isLock)
        {
            return;
        }

        target = Vector3.zero;
        //キーボード移動
        InputButton();

        //移動中かどうか
        if (target.magnitude != 0)
        {
            lastTarget = target;
            canShot = true;
        }
        else
        {
           // canShot = false;
        }
        Vector3 shotPos = new Vector3();
        if (ControlType == 0)
        {
            shotPos = Math.GetRotateVector(this.transform.up, mouseDragShotPos - mouseStartShotPos);
        }
        else
        {
            shotPos =  (mouseDragShotPos - mouseStartShotPos).normalized;
        }
        // 移動方向を取得する
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        Vector2 v = rd.velocity;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-shotPos.x, shotPos.y) * Mathf.Rad2Deg);

        target = (mouseDragMovePos - mouseStartMovePos).normalized;

        //位置の更新
        transform.position += target * speed * Time.deltaTime;

        Shot(currentBullet,shotPos);

        Clamp();        

        base.Update();

        //チートコード
        if (Input.GetKeyDown(KeyCode.M))
        {
            powRate = GameManager.GAMEPLAYER_MAXPOW;
            //delayRate = GameManager.GAMEPLAYER_MAXDELAY;
            score = 9999999;
        }

    }
    void InputButton()
    {
        if (Input.GetKey(KeyCode.D))//→
        {
            target.x += 1;
        }
        if (Input.GetKey(KeyCode.W))//↑
        {
            target.y += 1;
        }
        if (Input.GetKey(KeyCode.A))//←
        {
            target.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))//↓
        {
            target.y -= 1;
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    ChangeEquip(currentBullet+1);
        //    timer = 100;
        //}
    }

    void InputTouch()
    {

        //タッチ情報
        //Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (i >= 2) { break; }
            Debug.Log("Touch");


            //myTouches[i].phase

            //    //右側
            //    if (myTouches[i].position.x >= Screen.width / 2)
            //    {
            //        if (!isRightTouch)
            //        {
            //            mouseStartShotPos = mouseDragShotPos = myTouches[i].position;
            //            isRightTouch = true;
            //        }
            //        else
            //        {
            //            mouseDragShotPos = myTouches[i].position;
            //            //shotTarget = Math.GetRotateVector(mouseDragShotPos - mouseStartShotPos);
            //        }
            //    }
            //    //左側
            //    else
            //    {
            //        if (!isLeftTouch)
            //        {
            //            mouseStartMovePos = mouseDragMovePos = myTouches[i].position;
            //            isLeftTouch = true;
            //        }
            //        else
            //        {
            //            mouseDragMovePos = myTouches[i].position;
            //            //if(Math.Length(mouseDragMovePos-mouseStartMovePos)>7.0f)
            //            target = (mouseDragMovePos-mouseStartMovePos).normalized;
            //        }
            //    }
            //}
            //if (myTouches.Length == 0)
            //{
            //    isRightTouch = false;
            //    isLeftTouch = false;
            //    // isTouch = false;
            //}
        }
    }

    //void OnTriggerEnter2D(Collider2D c)
    //{
    //    if (c.gameObject.layer == 9)//Enemy
    //    {
    //        HP = (int)(HP * 0.9f);
    //    }
    //    if (c.gameObject.layer == 11)//EnemyBullet
    //    {
    //        HP -= c.gameObject.GetComponent<Bullet>().pow;
    //    }
    //}

            public override void SetType(int i)
        {
            ControlType = i;
        }

    void InputMass()
    {
        foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;
            Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Debug.LogFormat("{0}:いまタッチした", id);
                    if (t.position.x >= Screen.width / 2)
                    {
                        mouseDragShotPos = mouseStartShotPos = pos;
                    }
                    else
                    {
                        mouseStartMovePos = mouseDragMovePos = pos;
                    }
                        break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Debug.LogFormat("{0}:タッチしている", id);
                    if (t.position.x >= Screen.width / 2)
                    {
                        mouseDragShotPos  = pos;
                    }
                    else
                    {
                        mouseDragMovePos = pos;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    Debug.LogFormat("{0}:いま離された", id);
                    if (t.position.x >= Screen.width / 2)
                    {
                        if (ControlType == 0)
                        {
                            mouseStartShotPos = mouseDragShotPos = pos;
                        }
                        else
                        {
                            mouseDragShotPos = pos;
                        }
                    }
                    else
                    {
                        mouseStartMovePos = mouseDragMovePos = pos;
                    }
                    break;
            }
        }
    }
}