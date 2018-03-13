using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBullet : Bullet {
    float times;
    float range;
    float Rspeed;
    // Use this for initialization
    void Start()
    {
        Initialize();
        times = 3;
        times += Time.deltaTime;
        range = 10;
        Rspeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Rspeed -=0.1f;
        range += 0.5f;
        transform.position += transform.TransformDirection(Vector3.right * Mathf.Sin(times *Rspeed) * range * Time.deltaTime);

    }
}
