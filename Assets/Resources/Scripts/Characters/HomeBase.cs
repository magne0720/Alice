using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : Character {
    

	// Use this for initialization
	void Start () {
        Initialize();
        SetHPVer();
	}
	
	// Update is called once per frame
	void Update () {
        if (isLock)
        {
            return;
        }
        base.Update();
        Shot(0, target-transform.position);
        SearchObject();
        //target = Math.getDirectionDegree(target, 2);
    }


    public void Initialize()
    {
        base.Start();

        gameObject.layer = 8;//Player

        canShot = true;

        target = new Vector3(0, 1, 0);
       
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void SearchObject()
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
        if (obj != null)
        {
            target = obj.transform.position;
        }
    }
}
