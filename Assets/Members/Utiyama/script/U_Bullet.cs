using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Bullet : Bullet {
    // Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
	}
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // Update is called once per frame



}
