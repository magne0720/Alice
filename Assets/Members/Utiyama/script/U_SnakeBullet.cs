using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SnakeBullet : Bullet {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Sin(Time.time*10)*2;
        transform.position += transform.TransformDirection(Vector3.right * x*Time.deltaTime);

    }
}
