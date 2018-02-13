using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_DestroyArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
}
