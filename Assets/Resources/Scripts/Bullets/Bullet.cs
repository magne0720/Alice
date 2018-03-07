using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public float pow;
    public float recoil;
    protected bool isHit;
    public GameObject ExplosionObj;
    AudioSource Sound;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "PlayerBullet")
        {
            Sound = gameObject.AddComponent<AudioSource>();
            Sound.clip = clip;
            Sound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    public void Initialize()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (gameObject.layer == 10)//PlayerBullet
        {
            if (c.gameObject.layer == 9)//Enemy
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if(c.gameObject.layer==11)
            {
                isHit = true;
                Destroy(gameObject);
            }
        }
        else if (gameObject.layer==11)//EnemyBullet
        {
            if (c.gameObject.layer== 8 )//Player
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
                Destroy(gameObject);
            }
            else if (c.gameObject.layer == 10)
            {
                isHit = true;
                Destroy(gameObject);
            }
        }
    }
    public virtual void SetTarget(GameObject g)
    {

    }
    public void Explosion()
    {
        Instantiate(ExplosionObj, transform.position, Quaternion.identity);
    }
}