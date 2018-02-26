using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SnakeBullet : Bullet {
    float times;
	// Use this for initialization
	void Start () {
        times += Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.TransformDirection(Vector3.right * Mathf.Sin(Time.time*20f)*10*Time.deltaTime);

    }
}
