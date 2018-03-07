﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBullet : Bullet {
    float times;
    public float Timer;
    public float Scale;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if (times >= Timer)
        {
            if (ExplosionObj == null)
            {

            }
            else
            {

                ExplosionObj.transform.localScale = new Vector3(Scale, Scale, 1);
                ExplosionObj.transform.position = gameObject.transform.position;
                ExplosionObj.gameObject.layer = gameObject.layer;
                ExplosionObj.gameObject.tag = gameObject.tag;
                ExplosionObj.gameObject.GetComponent<Bullet>().pow = pow;
                Instantiate(ExplosionObj);
            }
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 9 || c.gameObject.layer == 11)
        {
            ExplosionObj.transform.localScale = new Vector3(Scale, Scale, 1);
            ExplosionObj.transform.position = gameObject.transform.position;
            ExplosionObj.gameObject.layer = gameObject.layer;
            ExplosionObj.gameObject.tag = gameObject.tag;
            //ExplosionObj.gameObject.GetComponent<Bullet>().pow = pow;
            Instantiate(ExplosionObj);
            Destroy(gameObject);
        }
        
        //base.OnTriggerEnter2D(c);
    }
}

