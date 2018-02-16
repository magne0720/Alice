using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_HomingBullet : Bullet
{

    public GameObject targetObject;
    public Vector3 MovePosition;

    /// 旋回速度
    public float rot = 3.0f;
    float waitTimer;

    // Use this for initialization
    void Start()
    {
        targetObject = SearchObject();
        MovePosition = transform.up;
        speed = 6.0f;
        rot = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject == null)
        {
            targetObject = SearchObject();
        }
        if (waitTimer < 1.0f)
        {
            waitTimer += Time.deltaTime;
        }
        else
        {
            Homing();
            //transform.position += (targetObject.transform.position-transform.position).normalized * Time.deltaTime;
        }
    }
    void Homing()
    {
        //ミサイルの方向ベクトル
        Vector3 fowardPos = (MovePosition).normalized;
        //ターゲットへの方向ベクトル
        Vector3 targetPos = (targetObject.transform.position-transform.position).normalized;

        float seta = Math.Dot2D(fowardPos, targetPos) / Math.Length(fowardPos) * Math.Length(targetPos);
        seta = Math.ragToDeg(seta);
        if (Math.Cross2D(fowardPos, targetPos) > 0)
        {
            seta *= -1;
        }
        //seta = Math.ragToDeg(seta);

        if (Input.GetKey(KeyCode.U))
        {
            seta = -2.0f;
        }
        if (Input.GetKey(KeyCode.I))
        {
            seta = 2.0f;
        }
        if (seta > 4.0f)
        {
            Debug.Log("→");
            seta = 4.0f;
        }
        else if (seta < -4.0f)
        {
            Debug.Log("←");
            seta = -4.0f;
        }
        else
        {
            Debug.Log("↑");
            seta = 0;
        }
        //Debug.Log("seta="+seta);
        seta = Math.degToRag(seta);
        //MovePosition = Math.getDirectionDegree(MovePosition, seta);
        //x' = x * cosθ - y * sinθ
        //y' = x * sinθ + y * cosθ
        float x = MovePosition.x * Mathf.Cos(seta-90) - MovePosition.y * Mathf.Sin(seta-90);
        float y = MovePosition.x * Mathf.Sin(seta-90) + MovePosition.y * Mathf.Cos(seta-90);

        MovePosition=new Vector3(x,y,0);

        Debug.DrawLine(MovePosition+transform.position , transform.position, Color.green, 2.0f);
        Debug.DrawLine(targetObject.transform.position, transform.position, Color.red, 2.0f);

        //transform.position +=MovePosition*speed*Time.deltaTime;


        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-MovePosition.x, MovePosition.y) * Mathf.Rad2Deg);
    }

    GameObject SearchObject()
    {

        //複数の場合
        float distance = float.MaxValue;
        float temp_dis = 0;
        GameObject obj = null;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in objs)
        {
            //距離を見る
            temp_dis = Math.Length(g.transform.position - transform.position);
            if (temp_dis <= distance)
            {
                //一番近いものを取得
                distance = temp_dis;

                obj = g;
            }
        }
        return obj;
    }
    void OnTriggerEnter2D(Collider2D c) { }

}
