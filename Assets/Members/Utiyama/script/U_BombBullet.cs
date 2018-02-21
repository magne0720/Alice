using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_BombBullet : Bullet {
    public GameObject BombDestroy;
    public float Area;
    public float DestroyTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject,DestroyTime);
    }
	
	// Update is called once per frame
	void Update () {
		
        transform.position += transform.up * speed * Time.deltaTime;
        
	}
    void searchArea(GameObject nowObj, string tagName, float Area)
    {
        float tmpDis = 0;           //距離用一時変数
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obj.transform.position, nowObj.transform.position);

            if (tmpDis<Area)
            {
                //Destroy(obj);
                obj.GetComponent<Character>().HP -= (int)pow;
            }
        }

    }
    

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 9||c.gameObject.layer==11)
        {
            searchArea(gameObject, "Enemy", Area);
            BombDestroy.transform.localScale = new Vector3(Area,Area,0);
            BombDestroy.transform.position = gameObject.transform.position;
            Instantiate(BombDestroy);
        }
        base.OnTriggerEnter2D(c);
    }
}
