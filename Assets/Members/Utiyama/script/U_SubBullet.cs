using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SubBullet : Bullet {
    public GameObject EndObject;
    float times;
    public float Timer;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if (times >= Timer)
        {
            if (EndObject == null)
            {

            }
            else
            {
                EndObject.transform.position = gameObject.transform.position;
             Instantiate(EndObject);

            }
            Destroy(gameObject);
        }
    }
}
