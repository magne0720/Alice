using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy {

    GameObject target;

	// Use this for initialization
	void Start ()
    {
        Initialize();
        //target = GameObject.FindGameObjectWithTag("HomeBase");
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("HomeBase");
        }
        if (Math.Length(target.transform.position - transform.position) > 4.0f)
        {
            Vector3 move = (target.transform.position - transform.position).normalized;

            transform.position += move * Time.deltaTime * speed;
            SetTarget(move);
            shotTarget = move;
        }
        base.Update();
    }
}
