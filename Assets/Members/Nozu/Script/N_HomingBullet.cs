using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_HomingBullet : Bullet {


    public GameObject targetObj = null;

    /// 旋回速度
    float rot = 4.0f;
     
    // Use this for initialization
    void Start () {

        //複数の場合
        float distance = float.MaxValue;
        float temp_dis = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in objs)
        {
            //距離を見る
            temp_dis = Math.Length(g.transform.position - transform.position);
            if (temp_dis <= distance)
            {
                //一番近いものを取得
                distance = temp_dis;
                targetObj = g;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Homing();
	}


    void Homing()
    {
        // ターゲット座標を取得
        Vector3 next = targetObj.transform.position;
        Vector3 now = transform.position;
        // 目的となる角度を取得する
        Vector3 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        // 角度差を求める
        float deltaAngle = Mathf.DeltaAngle(Math.Dot(next,now), targetAngle);
        float newAngle = Math.Dot(next,now);
        if (Mathf.Abs(deltaAngle) < rot)
        {
            // 旋回速度を下回る角度差なので何もしない
            speed += rot;
        }
        else if (deltaAngle > 0)
        {
            // 左回り
            newAngle += rot;
        }
        else
        {
            // 右回り
            newAngle -= rot;
        }
        Vector3 target=Math.getDirectionDegree(d, newAngle);


        // 画像の角度を移動方向に向ける
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-target.x, target.y) * Mathf.Rad2Deg));
        transform.position+=target * Time.deltaTime * speed;

    }
}
