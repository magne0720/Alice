using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTargetUI : MonoBehaviour {

    public Character player;
    private Vector2 mouseStartPosition,mouseMovePosition;
    public Sprite basetex;
    public Sprite arrowtex;
    bool isTouch;
    private GameObject baseObj;//基点
    private GameObject arrowObj;//矢印
    int touchcount;
    
    public enum TOUCH_MODE
    {
        LEFT,RIGHT
    };
    public TOUCH_MODE mode;

    // Use this for initialization
    void Start ()
    {
        CreateBase(ref baseObj, basetex,"BASE", 1);

        CreateBase(ref arrowObj, arrowtex,"ARROW", 2);

        //初回非表示
        baseObj.SetActive(false);
        arrowObj.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        InputMass();
        
            baseObj.transform.position = arrowObj.transform.position = mouseStartPosition;

        if (isTouch)
        {
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
    void CreateBase(ref GameObject obj,Sprite tex,string name,int order)
    {
        if (obj != null)
        {
            return;
        }

        obj = new GameObject();
        obj.name = name;
        obj.transform.parent = transform;
        obj.AddComponent<SpriteRenderer>().sprite = tex;
        obj.GetComponent<SpriteRenderer>().sortingOrder = order;
    }
    void CheckTouchCount(int cnt)
    {
        if (cnt == 0)
        {
            return;
        }
        touchcount = cnt;

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (mode == TOUCH_MODE.LEFT)
            {
                if (Input.GetTouch(i).position.x >= Screen.width / 2)
                {
                    isTouch = false;
                }
                else
                {
                    isTouch = true;
                }
            }
            else
            {
                if (Input.GetTouch(i).position.x <= Screen.width / 2)
                {
                    isTouch = false;
                }
                else
                {
                    isTouch = true;
                }
            }
        }
    }
    void InputMass()
    {
        foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Debug.LogFormat("{0}:いまタッチした", id);
                    if (t.position.x >= Screen.width / 2&&mode== TOUCH_MODE.RIGHT)
                    {
                        mouseStartPosition = mouseMovePosition = Camera.main.ScreenToWorldPoint(t.position);
                        isTouch = true;
                        baseObj.SetActive(true);
                        arrowObj.SetActive(true);
                    }
                    else if (t.position.x <= Screen.width / 2 && mode == TOUCH_MODE.LEFT)
                    {
                        mouseStartPosition = mouseMovePosition = Camera.main.ScreenToWorldPoint(t.position);
                        isTouch = true;
                        baseObj.SetActive(true);
                        arrowObj.SetActive(true);
                    }
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Debug.LogFormat("{0}:タッチしている", id);
                    if(isTouch)
                    if (t.position.x >= Screen.width / 2 && mode == TOUCH_MODE.RIGHT)
                    {
                        mouseMovePosition  = Camera.main.ScreenToWorldPoint(t.position);
                        }
                        else if (t.position.x <= Screen.width / 2 && mode == TOUCH_MODE.LEFT)
                        {
                        mouseMovePosition = Camera.main.ScreenToWorldPoint(t.position);
                        }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    Debug.LogFormat("{0}:いま離された", id);
                    if (t.position.x >= Screen.width / 2 && mode == TOUCH_MODE.RIGHT)
                    {
                       mouseStartPosition= mouseMovePosition = Camera.main.ScreenToWorldPoint(t.position);
                        baseObj.SetActive(false);
                        arrowObj.SetActive(false);
                        isTouch = false;
                    }
                    else if (t.position.x <= Screen.width / 2 &&mode == TOUCH_MODE.LEFT)
                    {
                        mouseStartPosition = mouseMovePosition = Camera.main.ScreenToWorldPoint(t.position);
                        baseObj.SetActive(false);
                        arrowObj.SetActive(false);
                        isTouch = false;
                    }
                    break;
            }
        }
    }
}
