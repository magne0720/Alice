using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTargetUI : MonoBehaviour {

    private Vector2 mouseStartPosition,mouseMovePosition;
    public Sprite basetex;
    public Sprite arrowtex;
    bool isTouch;
    private GameObject baseObj;//基点
    private GameObject arrowObj;//矢印
    
    public enum TOUCH_MODE
    {
        LEFT,RIGHT
    };
    public TOUCH_MODE mode;

    // Use this for initialization
    void Start ()
    {

        baseObj = new GameObject();
        baseObj.name = "BASE";
        baseObj.transform.parent = transform;
        baseObj.AddComponent<SpriteRenderer>().sprite = basetex;
        baseObj.GetComponent<SpriteRenderer>().sortingOrder = 1;

        arrowObj = new GameObject();
        arrowObj.name = "ARROW";
        arrowObj.transform.parent = transform;
        arrowObj.AddComponent<SpriteRenderer>().sprite = arrowtex;
        arrowObj.GetComponent<SpriteRenderer>().sortingOrder = 2;

        //初回非表示
        baseObj.SetActive(false);
        arrowObj.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (mode == TOUCH_MODE.LEFT)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 0) return;
        }
        else
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= 0) return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            mouseStartPosition =mouseMovePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);

            baseObj.transform.position =arrowObj.transform.position= mouseStartPosition;
            baseObj.SetActive(true);
            arrowObj.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
            baseObj.SetActive(false);
            arrowObj.SetActive(false);
        }
        if (isTouch)
        {
            mouseMovePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            arrowObj.transform.position = mouseMovePosition;

            Vector3 pos = baseObj.transform.position - arrowObj.transform.position;
            Vector3 pos2 = arrowObj.transform.position - baseObj.transform.position;

            if (Math.Length(pos) > 2.0f)
            {
                baseObj.transform.position -= pos.normalized * 0.6f;
            }
            arrowObj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-pos2.x, pos2.y) * Mathf.Rad2Deg);
        }
	}
}
