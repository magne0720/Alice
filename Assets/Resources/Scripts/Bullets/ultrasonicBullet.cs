using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultrasonicBullet : Bullet {
    public float Acceleration;
    public float Scale;
    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up * speed * Time.deltaTime;
        if (transform.localScale.x < Scale)
        {

            gameObject.transform.localScale += new Vector3(Acceleration,Acceleration, 0);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
