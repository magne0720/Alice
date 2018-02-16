using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_TabButtonScript : MonoBehaviour {

    //public Button TabButton;

    public T_TouchScript Ray;

    public Canvas ones;
    public Canvas twos;
    public Canvas threes;
   
	// Use this for initialization
	void Start () {
        ones.sortingOrder = 3;
        twos.sortingOrder = 2;
        threes.sortingOrder = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Ray.hit.collider.gameObject.name == "Tab1")
        {
            ones.sortingOrder = 3;
            twos.sortingOrder = 2;
            threes.sortingOrder = 1;
        }
        if (Ray.hit.collider.gameObject.name == "Tab2")
        {
            ones.sortingOrder = 1;
            twos.sortingOrder = 2;
            threes.sortingOrder = 1;
        }
        if (Ray.hit.collider.gameObject.name == "Tab3")
        {
            ones.sortingOrder = 2;
            twos.sortingOrder = 1;
            threes.sortingOrder = 3;
        }
        else
        {
            return;
        }


    }
    public void OnClick ()
    {

    }
}
