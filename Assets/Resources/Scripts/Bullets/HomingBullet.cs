using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    GameObject Enemy;
    Vector3 EnemyPos;
    public float RootSpeed;
    public float _Adjust;
    public float LowSpeed;
    public float MaxSpeed;
    public float PulssSpeed;
    // Use this for initialization
    void Start()
    {
        speed = LowSpeed;
        Destroy(gameObject, 10.0f);
        Enemy = searchTag(gameObject, "Enemy");
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

            //speed += Time.deltaTime;
            TargetLock();


            // 自身の向きに移動
            transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);
            /*float vx, vy,l,vxs,vys;
            vx = gameObject.transform.position.x - Enemy.transform.position.x;
            vy = gameObject.transform.position.y - Enemy.transform.position.y;
            l = (float)(System.Math.Sqrt(System.Math.Pow(vx,2)+ System.Math.Pow(vy, 2)));
            vxs = (vx / l);
            vys = (vy / l);
            */
            /*
            speed += Time.deltaTime;
            Vector3 move = (Enemy.transform.position - transform.position).normalized;
            transform.position += move * speed * Time.deltaTime/3;
            */
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
    void TargetLock()
    {

        ///自分の正面ベクトルをローカルからワールドへ変換
        ///自分から見た敵の方向ベクトルを算出
        Vector3 _ForwardVec = transform.TransformDirection(Vector3.up);
        Vector3 _TargetVec = (Enemy.transform.position - transform.position);

        ///　自身と敵の角度差・回転速度
        float _Angle = Vector3.Angle(_TargetVec.normalized, _ForwardVec.normalized);
        float _addAngle = (RootSpeed * Time.deltaTime);

        /// 外積

        Vector3 InOrOut = Vector3.Cross(_ForwardVec, _TargetVec);
        float cross = _ForwardVec.x * _TargetVec.y - _TargetVec.x * _ForwardVec.y;
        /// 内側か外側か（右か左か）
        int _IOO = cross > 0 ? 1 : -1;
        ///
        gameObject.transform.Rotate(0, 0, _IOO * _addAngle);
        if (_Angle >= _Adjust)
        {
        }
        else
        {
            if (speed < MaxSpeed)
            {
                speed += PulssSpeed;
            }
            //speed = MaxSpeed;
        }
    }
}
