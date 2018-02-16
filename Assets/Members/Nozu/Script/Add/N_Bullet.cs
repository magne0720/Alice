using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Bullet : MonoBehaviour {

    float speed;
    float timer;
    public int pow;
    public float recoil;

    // Use this for initialization
    void Start () {
        speed = 12.0f;
        pow = 5;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        transform.position += transform.up * speed*Time.deltaTime;
        if (timer >= 5.0f)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        //if (c.tag == "Enemy")
        //{
        //    c.gameObject.GetComponent<N_Character>().HP -= pow;
        //}

        Destroy(gameObject);
    }
}
