using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // Use this for initialization
    public float Speed;
    public float Des;
	void Start () {
        Speed = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        Des += Time.deltaTime;
        gameObject.transform.position +=transform.up*Speed;
        if (Des > 2)
        {
            Destroy(gameObject);
        } 
	}
}
