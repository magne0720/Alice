using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_DamageField : MonoBehaviour {
    public int damage;
    public float timer;
    float time;
    public List<GameObject> Enemy;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        for(int i = 0; i< Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            
            Enemy.Add(c.gameObject);
            
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.layer == 9&&time > timer)
        {
            for (int i = 0; i < Enemy.Count; i++)
            {
                Enemy[i].gameObject.GetComponent<Character>().HP -= damage;
            }
            time = 0;
        }
    }
    void OnTriggerExit(Collider c)
    {
        Enemy.Remove(c.gameObject);
        Debug.Log("aaaa");
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
                //obj.GetComponent<Character>().HP -= (int)pow;
            }
        }

    }
}
