using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_ButtonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClick(string type)
    {
        Debug.Log("button"+type.ToString());
    }
    public void OnButtonClick()
    {
        Debug.Log("click");
    }
}
