using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_EnemyHoming : Enemy {

    GameObject targetObject = null;

    /// 旋回速度
    float rot = 1.0f;


    // Use this for initialization
    void Start() {
        Initialize();


        targetObject = GameObject.FindGameObjectWithTag("Player");

        //複数の場合
        float distance = float.MaxValue;
        float temp_dis = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in objs)
        {
            //距離を見る
            temp_dis = Math.Length(g.transform.position - transform.position);
            if (temp_dis <= distance)
            {
                //一番近いものを取得
                distance = temp_dis;
                targetObject = g;
            }
        }
    }
    /// 角度と速度から移動速度を設定する
    void SetVelocity(float direction, float speed)
    {
        var vx = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        var vy = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;

        rigidbody2D.velocity = new Vector2(vx, vy);
    }

    /// 更新
    void Update()
    {

        if (targetObject == null)
        {
            return;
        }
        Homing();

        SetDirection();
        
        base.Update();
    }
    void Homing()
    {
        // ターゲット座標を取得
        Vector3 next = targetObject.transform.position;
        Vector3 now = transform.position;
        // 目的となる角度を取得する
        Vector3 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        // 角度差を求める
        float deltaAngle = Mathf.DeltaAngle(Direction, targetAngle);
        float newAngle = Direction;
        if (Mathf.Abs(deltaAngle) < rot)
        {
            // 旋回速度を下回る角度差なので何もしない
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

        // 新しい速度を設定する
        SetVelocity(newAngle, speed);

    }
}
