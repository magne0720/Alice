using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_BounsBullet : Bullet {
    GameObject g;
    // Use this for initialization
    void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);
        
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 9)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }
    }
}
