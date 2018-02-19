using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy {

    int currentCount;
    public List<Vector2> moves;//パターンのリスト
    float moveTimer;

    // Use this for initialization
    void Start()
    {
        Initialize();
        moveTimer = 0;

        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {

        moveTimer += Time.deltaTime;
        if (moveTimer >= 1.0f)
        {
            moveTimer = 0;
            currentCount++;
        }
        if (currentCount >= moves.Count)
        {
            currentCount = 0;
        }
        Vector2 pos = moveTimer * moves[currentCount] + (1 - moveTimer) * (Vector2)transform.position;

        transform.rotation = Quaternion.Euler(0, 0, moveTimer);
        transform.position = (Vector3)pos;

        SetTarget(target);

        Shot(0);

        base.Update();
    }
}
