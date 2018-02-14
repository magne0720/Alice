using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Spawn : MonoBehaviour {

    private float timer;
    public float spawnTimer;
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            timer = 0;
            Instantiate(obj,transform.position,transform.rotation);
        }
	}
}
