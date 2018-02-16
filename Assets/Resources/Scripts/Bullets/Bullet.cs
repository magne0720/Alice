using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{

    float timer;
    public float speed;
    public float pow;
    public float recoil;

    // Use this for initialization
    void Start()
    {
        speed = 12.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if (timer >= 5.0f)
        {
            Destroy(gameObject);
        }
    }
    public void Initialize()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (gameObject.layer == 10)//PlayerBullet
        {
            if (c.gameObject.layer == 9)//Enemy
            {
                c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if(c.gameObject.layer==11)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.layer==11)//EnemyBullet
        {
            if (c.gameObject.layer== 8 )//Player
            {
                c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if (c.gameObject.layer == 10)
            {
                Destroy(gameObject);
            }
        }
    }
}