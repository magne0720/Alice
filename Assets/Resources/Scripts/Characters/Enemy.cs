using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    public void Initialize()
    {
        base.Start();

        gameObject.layer = 9;//Player

        canShot = true;

        if (target == Vector3.zero)
        {
            target = new Vector3(0, -1, 0);
        }
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += target * speed * Time.deltaTime;

        SetTarget(target);

        Shot(2);

        base.Update();
    }
    public void SetTarget(Vector3 t)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-t.x, t.y) * Mathf.Rad2Deg);
    }
}
