using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SickleBullet : Bullet {
    public float Radius;
    private float timer;
	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Debug.Log(Time.time);
        int _IOO = transform.rotation.y==0 ? 1 : -1;
        Radius -= 0.02f;
        speed += 0.2f;
        Vector3 vec3= new Vector3(Mathf.Sin(Radius * timer) * speed * Time.deltaTime, -1 * Mathf.Cos(Radius * timer) * speed * Time.deltaTime, 0);
        transform.position += transform.TransformDirection(vec3);
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (gameObject.layer == 10)//PlayerBullet
        {
            if (c.gameObject.layer == 9)//Enemy
            {
                isHit = true;
                //c.gameObject.GetComponent<Character>().HP -= (int)pow;
                int HPD=c.gameObject.GetComponent<Character>().HP-=(int)pow;
                if (HPD > 0)
                {
                    Destroy(gameObject);
                }
            }
            else if (c.gameObject.layer == 11)
            {
                isHit = true;
            }
        }
        else if (gameObject.layer == 11)//EnemyBullet
        {
            if (c.gameObject.layer == 8)//Player
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
}
