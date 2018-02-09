using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_HomeBase : N_Character {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("Q"))
        {
            HP--;

            Debug.Log(HP);
        }
	}
}
