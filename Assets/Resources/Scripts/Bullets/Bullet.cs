﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float timer;
    public float speed;
    public float pow;
    public float recoil;
    protected bool isHit;
    // Use this for initialization
    void Start()
    {
        speed = 12.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if (timer >= 5.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (gameObject.layer == 10)//PlayerBullet
        {
            if (c.gameObject.layer == 9)//Enemy
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if(c.gameObject.layer==11)
            {
                isHit = true;
                Destroy(gameObject);
            }
        }
        else if (gameObject.layer==11)//EnemyBullet
        {
            if (c.gameObject.layer== 8 )//Player
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if (c.gameObject.layer == 10)
            {
                isHit = true;
                Destroy(gameObject);
            }
        }
    }
    
}