using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {    

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5.0f);
        canShot = true;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        transform.position += new Vector3(0, -1*speed*Time.deltaTime, 0);
        transform.Rotate(0, 0, 180*speed*Time.deltaTime);
        target = new Vector3(0, -1, 0); 

        timer += Time.deltaTime;
        if (timer >= delay && canShot)
        {
            timer = 0;
            GameObject g=Instantiate(bullet, transform.position, transform.rotation);
            g.gameObject.layer = 11;
        }
    }
}
