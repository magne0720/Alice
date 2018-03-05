using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Bullet {
    GameObject Player;
    public float scale;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.parent = Player.transform;
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        gameObject.transform.localScale += new Vector3(0, scale*Time.deltaTime, 0);
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
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
}