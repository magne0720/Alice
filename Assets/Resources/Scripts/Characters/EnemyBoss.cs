using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy {

    int currentCount;
    public List<Vector2> moves;//パターンのリスト
    public List<Vector2> attacks;//パターンのリスト
    float moveTimer;
    Vector2 afterPos;

    // Use this for initialization
    void Start()
    {
        Initialize();
        moveTimer = 0;
        afterPos = transform.position;

        gameObject.tag = "Enemy";

    }

    // Update is called once per frame
    void Update()
    {

        moveTimer += Time.deltaTime;
        if (moveTimer >= 1.0f)
        {
            afterPos = transform.position;
            moveTimer = 0;
            currentCount++;
            if (currentCount >= moves.Count)
            {
                currentCount = 0;
            }
        }
        else
        {
        }
        Vector2 pos = moveTimer * moves[currentCount] + (1 - moveTimer) * afterPos;
        //target =   (Vector3)pos- transform.position;
        shotTarget = attacks[currentCount];

        //SetTarget(attacks[currentCount]);

        transform.position = pos;
        

        base.Update();
    }
}
