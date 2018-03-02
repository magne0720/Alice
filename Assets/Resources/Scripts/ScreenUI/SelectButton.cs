using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour {
    
    public enum Select
        {
            OK,
            CANCEL
        }
    
    public Select select;

    public bool flg;

    // Use this for initialization
    void Start () {

        flg = false;
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        flg = true;
    }
}