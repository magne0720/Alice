﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet :Bullet {
    
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.2f);
        gameObject.layer = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 9)
        {
            c.GetComponent<Character>().HP -= (int)pow;
            Debug.Log("aaa");
        }

        if (c.gameObject.layer == 10 || c.gameObject.layer == 11)
        {
            //Destroy(c.gameObject);
        }
    }
}
