using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_SatelliteBullet : Bullet {

    GameObject target;
    Vector3 pos;
    public enum SATELLITE_TYPE
    {
        LEFT=-1,RIGHT =1
    };
    public SATELLITE_TYPE type;


    // Use this for initialization
    void Start()
    {
            pos = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update () {


        pos = Math.getDirectionDegree(pos, 5.0f*(int)type,1);

        if (target != null)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(pos.y*(int)type, pos.x*(int)type) * Mathf.Rad2Deg);
            transform.position = pos + target.transform.position;
        }
        else
        {
            transform.position += speed * transform.up*Time.deltaTime;
        }
    }
    public override void SetTarget(GameObject g)
    {
        target = g;
    }
}
