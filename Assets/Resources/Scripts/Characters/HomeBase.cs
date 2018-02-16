using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : Character {



	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        Shot(0, target);
        target = Math.getDirectionDegree(target, 2);
    }


    public void Initialize()
    {
        base.Start();

        gameObject.layer = 8;//Player

        canShot = true;

        target = new Vector3(0, 1, 0);
       
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
