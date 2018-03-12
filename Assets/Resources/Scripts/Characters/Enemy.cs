using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    public int enemtype;

    public void Initialize()
    {
        //LoadData(enemtype);
        base.Start();

        gameObject.tag = "Enemy";
        gameObject.layer = 9;//Enemy

        canShot = true;

        if (target == Vector3.zero)
        {
            target = new Vector3(0, -1, 0);
        }
        currentBullet = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();

        SetHPVer();
    }

    // Use this for initialization
    public virtual void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //transform.position += target * speed * Time.deltaTime;


        //SetDirection();

        if (HP <= 0)
        {
            GameManager.KilledValue++;
        }

        base.Update();

        Shot(currentBullet,shotTarget);
    }
    public void SetTarget(Vector3 t)
    {
        shotTarget = t;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-t.x, t.y) * Mathf.Rad2Deg);
    }
    protected void InitData(int num=0)
    {
        //LoadData(num);
    }
    void SetData(int hp,float sp,int sc)
    {
        HP = hp;
        speed = sp;
        score = sc;
    }
    void LoadData(int num)
    {
        string temp = Resources.Load("EnemyData_"+num, typeof(TextAsset)).ToString();
        int count = 0;
        //行分け
        string[] lineText = temp.Split('\n');
        foreach (string line in lineText)
            if (line.StartsWith("#"))
            {
                //コメントアウトの部分なので何もしない
            }
            else
            {
                //タブ区切り(.CSV) 
                string[] dataText = line.Split(',');
                HP = int.Parse(dataText[0]);
                speed = float.Parse(dataText[1]);
                score = int.Parse(dataText[2]);
                count++;
            }
    }
}
