using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Bullet {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);
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