using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Bullet {
    GameObject Player;
    public float scale;
    public int damage;
    public float timer;
    float time;
    public List<GameObject> Enemy;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.parent = Player.transform;
        Destroy(gameObject, 4);
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.localScale.y < 40)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            gameObject.transform.localScale += new Vector3(0, scale * Time.deltaTime, 0);
        }
        time += Time.deltaTime;
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "Enemy")
        {

            Enemy.Add(c.gameObject);

        }
        if (gameObject.layer == 10)//PlayerBullet
        {
            if (c.gameObject.layer == 9)//Enemy
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
            }
            else if (c.gameObject.layer == 11)
            {
                isHit = true;
            }

        }
        else if (gameObject.layer == 11)//EnemyBullet
        {
            if (c.gameObject.layer == 8)//Player
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
            }
            else if (c.gameObject.layer == 10)
            {
                isHit = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.layer == 9 && time > timer)
        {
            for (int i = 0; i < Enemy.Count; i++)
            {
                Enemy[i].gameObject.GetComponent<Character>().Damage(damage);
            }
            time = 0;
        }
    }
    void OnTriggerExit(Collider c)
    {
        Enemy.Remove(c.gameObject);
    }
    void searchArea(GameObject nowObj, string tagName, float Area)
    {
        float tmpDis = 0;           //距離用一時変数
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obj.transform.position, nowObj.transform.position);

            if (tmpDis < Area)
            {
                //Destroy(obj);
                //obj.GetComponent<Character>().HP -= (int)pow;
            }
        }

    }
}