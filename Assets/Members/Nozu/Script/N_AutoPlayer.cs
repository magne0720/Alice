using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_AutoPlayer : Character {

	// Use this for initialization
	void Start () {
        canShot = true;
        Option();
	}
	
	// Update is called once per frame
	void Update () {
        Shot();
	}
}
