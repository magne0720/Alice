using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_TapText : MonoBehaviour {

    public Text text;
    Vector2[] starts;
    Vector2[] ends;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        starts = new Vector2[10];
        ends = new Vector2[10];
    }

    // Update is called once per frame
    void Update () {
        text.text = "";
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            starts[i] = myTouches[i].position;
            text.text += "[" + (int)myTouches[i].deltaPosition.x + "," + (int)myTouches[i].deltaPosition.y+ "]\n";
        }
        //text.text += Screen.width.ToString();
        text.text+="Tap["+(int)Input.mousePosition.x+","+(int)Input.mousePosition.y+"]";
    }
}
