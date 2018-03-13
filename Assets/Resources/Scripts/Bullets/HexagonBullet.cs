using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonBullet : Bullet {
    public GameObject Bullets;
    float time;
    public float DesTime;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, DesTime);
        Initialize();
        time = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        //  gameObject.transform.Rotate(0, 0,50*Time.deltaTime);
        time += Time.deltaTime;
        if (time > 0.8)
        {
            CreateBulet(0f);
            CreateBulet(45f);
            CreateBulet(90f);
            CreateBulet(135f);
            CreateBulet(180f);
            CreateBulet(225f);
            CreateBulet(270f);
            CreateBulet(315f);
            time = 0;
        }
    }
    void CreateBulet(float rotate)
    {

        Bullets.transform.position = gameObject.transform.position;
        Bullets.transform.rotation = Quaternion.AngleAxis(rotate + gameObject.transform.rotation.z, -Vector3.forward);

        Bullets.gameObject.layer = gameObject.layer;
        Bullets.gameObject.tag = gameObject.tag;
        Bullets.gameObject.GetComponent<Bullet>().pow = pow;
        Instantiate(Bullets);
    }
}
