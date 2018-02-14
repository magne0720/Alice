using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_HomingBullet : Bullet {
    public GameObject Enemy;
    Vector3 EnemyPos;
	// Use this for initialization
	void Start () {
        speed = 12.0f;
        Destroy(gameObject,2.0f);
        Enemy = searchTag(gameObject,"Enemy");
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            Enemy = searchTag(gameObject, "Enemy");

            //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        else
        {


            speed += Time.deltaTime;
            Vector3 move = (Enemy.transform.position - transform.position).normalized;
            transform.position += move * speed * Time.deltaTime/3;
        }

        //transform.position += transform.up * speed * Time.deltaTime;
    }
    GameObject searchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

}
