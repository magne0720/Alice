using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBullet : MonoBehaviour {
    public float time;
    public List<GameObject> target;
    // Use this for initialization
    void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent, time);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void searchArea(GameObject nowObj, string tagName, float Area)
    {
        float tmpDis = 0;           //距離用一時変数
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obj.transform.position, nowObj.transform.position);

            if (tmpDis < Area)
            {
                //Destroy(obj);

            }
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 11 || c.gameObject.layer == 10)
        {
            Destroy(c);
        }
        if (c.gameObject.layer == 9)
        {
            c.gameObject.GetComponent<Character>().HP -= 1000;
        }


    }
}
