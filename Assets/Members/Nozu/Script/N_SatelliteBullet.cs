using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_SatelliteBullet : Bullet {

    GameObject target;

    Vector3 pos;

    // Use this for initialization
    void Start()
    {
            pos = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update () {


        pos = Math.getDirectionDegree(pos, 5.0f,1);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg);
        if (target != null)
        {
            transform.position = pos + target.transform.position;
        }
    }
    public override void SetTarget(GameObject g)
    {
        target = g;
    }
}
