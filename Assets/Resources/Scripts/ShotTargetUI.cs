using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTargetUI : MonoBehaviour {

    public Vector2 mouseStartPosition,mouseMovePosition;
    public Sprite arrow;
    bool isTouch;
    private GameObject obj;//矢印

	// Use this for initialization
	void Start () {
        obj = new GameObject();
        obj.name = "ARROW";
        obj.transform.parent = transform;
        obj.AddComponent<SpriteRenderer>().sprite = arrow;

}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        mouseMovePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        obj.transform.position = mouseMovePosition;

	}
}
