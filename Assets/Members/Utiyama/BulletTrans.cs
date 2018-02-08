using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrans : MonoBehaviour {
    int BulletNumber;
    public List<GameObject> Bullet;
    private int BulletCount;
    // Use this for initialization
    void Start()
    {
        BulletNumber = 0;
        BulletCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            switch (BulletNumber)
            {
                case 0:
                    BulletCreate(0, 2);
                    break;
                case 1:
                    BulletCreate(1, 15);
                    break;
                case 2:
                    BulletCreate(2, 30);
                    break;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(0, 0, 3);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(0, 0, -3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletNumber = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletNumber = 2;
        }
    }
    void BulletCreate(int BulletNum, int BulletCountM)
    {
        BulletCount++;
        Debug.Log(BulletCount);
        if (BulletCount > BulletCountM)
        {
            Bullet[BulletNum].transform.position = gameObject.transform.position;
            Bullet[BulletNum].transform.rotation = gameObject.transform.rotation;
            Instantiate(Bullet[BulletNum]);
            BulletCount = 0;
        }
    }
}