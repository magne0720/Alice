using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Bullet
{
    public List<GameObject> Mother = new List<GameObject>();
    // Use this for initialization

    void Start()
    {
        Mother = GetAll(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        int count = 0;
        foreach (GameObject g in Mother)
        {
            if (g == null)
            {
                Mother.RemoveAt(count);
            }
            count++;
            continue;
        }
        */
        for (int i = 0; i < Mother.Count; i++)
        {
            if (Mother[i] == null)
            {
                Mother.RemoveAt(i);
            }
        }
        if (Mother.Count == 0)
        {
            Destroy(gameObject);
        }
    }
    public List<GameObject> GetAll(GameObject obj)
    {

        List<GameObject> allChildren = new List<GameObject>();

        GetChildren(obj, ref allChildren);

        return allChildren;

    }
    //子要素を取得してリストに追加

    public void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {

        Transform children = obj.GetComponentInChildren<Transform>();

        //子要素がいなければ終了

        if (children.childCount == 0)
        {
            return;
        }
        Debug.Log("layer=" + gameObject.layer);

        foreach (Transform ob in children)
        {
            ob.gameObject.layer = gameObject.layer;
            ob.gameObject.tag = gameObject.tag;
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }
}