using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_EnemyBoss : Enemy {

    int currentCount;
    public List<Vector2> moves;//パターンのリスト
    float moveTimer;

	// Use this for initialization
	void Start () {
        Initialize();
        moveTimer = 0;

	}
	
	// Update is called once per frame
	void Update () {
        
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
        Vector2 pos = moveTimer*moves[currentCount] + (1-moveTimer)*(Vector2)transform.position;

        transform.position = (Vector3)pos;

        SetTarget(target);

        Shot(2);

        base.Update();
    }
}
