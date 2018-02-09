using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_EnemyBulletDirection : MonoBehaviour {
    public List<GameObject> EnemyBullet = new List<GameObject>();
    int BulletNumber;
    int BulletCount;
    public GameObject player;
	// Use this for initialization
	void Start () {
        BulletNumber = 0;
        BulletCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        EnemyBulletCreate();
	}
    void EnemyBulletCreate()
    {
        BulletCount++;
        if (BulletCount > 60)
        {
            LookAt2D(player);
            EnemyBullet[BulletNumber].transform.position = gameObject.transform.position;
            Instantiate(EnemyBullet[BulletNumber]);
            BulletCount = 0;
        }
    }
    void LookAt2D(GameObject target)
    {
        // 指定オブジェクトと回転さすオブジェクトの位置の差分(ベクトル)
        Vector3 pos = target.transform.position - transform.position;
        // ベクトルのX,Yを使い回転角を求める
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        // 回転角は右方向が0度なので-90しています
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        // 回転
        EnemyBullet[BulletNumber].transform.rotation = rotation;
    }
}
