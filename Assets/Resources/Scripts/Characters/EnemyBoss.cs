using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy {

    int currentCount;
    public List<Vector2> moves;//パターンのリスト
    public List<Vector2> attacks;//パターンのリスト
    public List<int> moveCounts;//パターンの秒数
    float moveTimer;
    Vector2 afterPos,beforePos;

    // Use this for initialization
    public override void Start()
    {
        Debug.Log("LOGOGOGOGOG");
        Initialize();
        moveTimer = 0;
        afterPos = transform.position;

        gameObject.tag = "Enemy";

        beforePos = moves[currentCount];
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (moveTimer >=moveCounts[currentCount])
        {
            afterPos = transform.position;
            moveTimer = 0;
            currentCount++;
            if (currentCount >= moves.Count)
            {
                currentCount = 0;
            }
            beforePos = moves[currentCount];
            if (moveCounts[currentCount] == 0)
            {
                moveCounts[currentCount] = 1;
            }
        }
        else
        {
        }
        Vector2 pos = moveTimer/moveCounts[currentCount] * beforePos + (1 - moveTimer/moveCounts[currentCount]) * afterPos;
        //target =   (Vector3)pos- transform.position;
        
        SetTarget(attacks[currentCount]);

        transform.position = pos;
        
        moveTimer += Time.deltaTime;

    }
}
