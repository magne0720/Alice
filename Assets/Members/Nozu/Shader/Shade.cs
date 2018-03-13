using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shade : MonoBehaviour {

    float timer = 0;
    Image image;
    
    // Use this for initialization
    void Start () {
        timer = 0;
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime/3;
        if (timer >= 1.0f)
        {
            timer = 0;
        }
        float r = Mathf.Cos(timer * 2.0f * Mathf.PI);
        image.color = new Color(r,r,r,r);
	}
}
