using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_HexagonBullet : MonoBehaviour {
    public GameObject Bullets;
    float time;
	// Use this for initialization
	void Start () {
        time = 0;
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
      //  gameObject.transform.Rotate(0, 0,50*Time.deltaTime);
        time += Time.deltaTime;
        Debug.Log(time);
        if (time > 0.2)
        {
            CreateBulet(0f);
            CreateBulet(60f);
            CreateBulet(120f);
            CreateBulet(180f);
            CreateBulet(240f);
            CreateBulet(300f);
            time = 0;
            Debug.Log("aaa");
        }
    }
    void CreateBulet(float rotate)
    {
        
        Bullets.transform.position = gameObject.transform.position;
        Bullets.transform.rotation = Quaternion.AngleAxis(rotate, -Vector3.forward);
        Instantiate(Bullets);
    }
}
