using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Bullet : MonoBehaviour {
    // Use this for initialization
    public float Speed;
    public static int Relod;
	protected void Start () {
        Speed = 10f;
        Destroy(gameObject, 2.0f);
	}

    // Update is called once per frame
    protected void Update () {
        gameObject.transform.position +=transform.up*Speed*Time.deltaTime;
        
	}
}
