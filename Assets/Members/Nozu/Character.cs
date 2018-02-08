﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int HP;
    public float speed;
    public Vector3 target;
    public float delay;
    protected float timer;
    public bool canShot;
    public GameObject bullet;

    public GameObject deathObj;

    // Use this for initialization
    protected void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
        DeathCheck();
	}

    void DeathCheck()
    {
        if (HP <= 0)
        {
            Instantiate(deathObj);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        HP--;
    }
}
