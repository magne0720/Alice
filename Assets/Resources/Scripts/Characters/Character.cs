using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int MAX_HP;
    public int HP;//体力
    public float speed;//速度
    public int score;//スコア
    public float delay;//反動(次の弾が出るまでの時間)
    public bool canShot;//弾を撃つかどうか
    public float powRate;//攻撃倍率
    public float delayRate;//反動軽減率
    public int currentBullet;//選択中の弾番号
    public GameObject[] Bullets;//射出する弾
    public GameObject deathObj;//死んだときに出す弾
    public GameObject hpVerObj;  //HPバー

    protected Vector3 target;
    protected float timer;
    protected Rigidbody2D rigidbody2D = null;

    /// 移動角度
    public float Direction
    {
        get { return Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg; }
    }
    // Use this for initialization
    protected void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;

        if (hpVerObj != null)
        {
            GameObject g = Instantiate(hpVerObj)as GameObject;
            g.name = transform.name + "HPver";
            g.GetComponent<HPVer>().SetCharacter(this);
        }
        MAX_HP = HP;
    }

    // Update is called once per frame
    protected void Update()
    {
        HealthCheck();
    }

    void HealthCheck()
    {
        if (HP > MAX_HP)
        {
            HP = MAX_HP;
        }

        if (HP <= 0)
        {
            gameObject.layer = 13;
            for (int i = 0; i < score*0.1+1; i++)
            {
                Instantiate(deathObj, transform.position, new Quaternion());
            }
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 8|| c.gameObject.layer == 9)//機体
        {
            HP -= MAX_HP/10;
            if (gameObject.layer == 9)
            {
                HP = 0;
            }
        }
        if (c.gameObject.layer == 10|| c.gameObject.layer == 11)//弾
        {
            HP -= (int)c.gameObject.GetComponent<Bullet>().pow;
        }
    }
    public void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    /// <summary>
    /// Bulletsの番号を入れて発射する
    /// どちらでもない場合は引数はいらない
    /// </summary>
    /// <param name="type"></param>
    public void Shot(int num = 0, Vector3 dir = new Vector3())
    {
        if (Bullets == null)
            return;

        if (num >= Bullets.Length)
        {
            Debug.Log("Shot-OverNumver");
            return;
        }

        timer += Time.deltaTime;
        if (timer >= delay && canShot)
        {
            timer = 0;
            GameObject obj = Instantiate(Bullets[num], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
            if (gameObject.layer == 8)
                obj.gameObject.layer = 10;
            else if (gameObject.layer == 9)
                obj.gameObject.layer = 11;

            //攻撃倍率を弾に加算
            obj.GetComponent<Bullet>().pow *= powRate;

            //反動を設定(軽減率も計算)
            delay = obj.GetComponent<Bullet>().recoil - delayRate;
        }
    }
    public void SetDirection()
    {

        // 画像の角度を移動方向に向ける
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Direction));
    }
}
