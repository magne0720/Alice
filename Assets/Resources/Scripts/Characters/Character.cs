using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int HP;//体力
    public float speed;//速度
    public int score;//スコア
    public float delay;//反動(次の弾が出るまでの時間)
    public bool canShot;//弾を撃つかどうか
    public GameObject bullet;//射出する弾
    public float powRate;//攻撃倍率
    public float delayRate;//反動軽減率

    public GameObject deathObj;
    public GameObject hpVerObj;  

    protected Vector3 target;
    protected float timer;

        // Use this for initialization
    protected void Start()
    {
        if (hpVerObj != null)
        {
            GameObject g = Instantiate(hpVerObj)as GameObject;
            g.name = transform.name + "HPver";
            g.GetComponent<HPVer>().SetCharacter(this);
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        DeathCheck();
    }

    void DeathCheck()
    {
        if (HP <= 0)
        {
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
            HP = 0;
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
    /// type＝Playerなら1,Enemyなら2と入力
    /// どちらでもない場合は引数はいらない
    /// </summary>
    /// <param name="type"></param>
    public void Shot(int type=0)
    {
        if (bullet == null)
            return;


        timer += Time.deltaTime;
        if (timer >= delay && canShot)
        {
            timer = 0;
            GameObject g = Instantiate(bullet, transform.position, transform.rotation);
            if (type == 1)
                g.gameObject.layer = 10;
            else if (type == 2)
                g.gameObject.layer = 11;

            //攻撃倍率を弾に加算
            g.GetComponent<Bullet>().pow *= powRate;

            //反動を設定(軽減率も計算)
                delay = g.GetComponent<Bullet>().recoil*delayRate;
        }
    }
}
