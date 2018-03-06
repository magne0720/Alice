using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    Vector3 lastTarget;
    bool isTouch;

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

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouse.x);
        //最初のタッチ位置
        if (Input.GetMouseButtonDown(0))
        {
            //if (mouse.x >=0)
            //{
                mouseStartShotPos = mouseDragShotPos = mouse;
            //}
            //else
           // {
                mouseStartMovePos = mouseDragMovePos = mouse;
            //}
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseStartMovePos = mouseDragMovePos = Vector2.zero;
            //mouseStartShotPos = Vector3.zero;
            isTouch = false;
        }
        //ドラッグしてる間
        if (isTouch)
        {
         //   if (mouse.x >= 0)
            //{
                mouseDragShotPos = mouse;
            //}
            //else
            //{
                mouseDragMovePos = mouse;
           // }
        }

        if (Math.Length(mouseDragShotPos - mouseStartShotPos) > 2.0f)
        {
            mouseStartShotPos += (mouseDragShotPos-mouseStartShotPos).normalized * 0.6f;
        }
        Vector3 shotPos = mouseDragShotPos - mouseStartShotPos;
        target = (mouseDragMovePos - mouseStartMovePos).normalized;

        // 移動方向を取得する
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        Vector2 v = rd.velocity;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-shotPos.x, shotPos.y) * Mathf.Rad2Deg);

        //位置の更新
        transform.position += target * speed * Time.deltaTime;

        Shot(currentBullet,shotPos);

        Clamp();

        base.Update();

        //チートコード
        if (Input.GetKeyDown(KeyCode.M))
        {
            powRate = 3000;
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
        if (Input.GetMouseButtonDown(1))
        {
            ChangeEquip(currentBullet+1);
            timer = 100;
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
}