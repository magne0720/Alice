using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {    

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -1*speed*Time.deltaTime, 0);
	}
}
