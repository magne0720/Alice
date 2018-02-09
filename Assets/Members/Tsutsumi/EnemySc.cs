using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{

    public int EnemyHP;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Damage();

        //enemy死ぬ
        if(EnemyHP == 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log(EnemyHP);
    }
    void Damage()
    {
        //バーが減る条件式よろ
        if (Input.GetKeyDown("space"))
        {
            --EnemyHP;
        }
    }
}
