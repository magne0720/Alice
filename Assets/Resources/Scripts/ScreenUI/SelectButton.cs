using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour {

    public VirtualCharactor Vc;

    public enum Select
        {
            OK,
            BACK
        }

    public Select select;

    // Use this for initialization
    void Start () {
	        
        
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        switch(select)
        {
            case Select.OK:

                break;
            case Select.BACK:

                break;
        }
    }
}
