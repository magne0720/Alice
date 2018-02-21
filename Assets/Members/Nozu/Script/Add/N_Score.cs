using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Score : MonoBehaviour {

    public GameObject targetObj;
    private float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
        speed = 0;
        targetObj = GameObject.FindGameObjectWithTag("Player");
        gameObject.layer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (targetObj == null)
        {
            targetObj = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            speed += Time.deltaTime;
            Vector3 move = (targetObj.transform.position - transform.position).normalized;
            transform.position += move * speed * Time.deltaTime;
        }


	}
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Character>().score += (int)speed*25;
            Destroy(gameObject);
        }
    }
}
