using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // Use this for initialization
    public float Speed;
    public int Relod;
	protected void Start () {
        Speed = 0.2f;
        Destroy(gameObject, 2.0f);
	}

    // Update is called once per frame
    protected void Update () {
        gameObject.transform.position +=transform.up*Speed;
        
	}
}
