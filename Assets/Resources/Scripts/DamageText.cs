using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {
    
    public float destTime;
    private float timer;
    private int point;
    private Text text;
    public Color StartCol,EndCol;
    public float StartSize;
    private Vector3 size;

	// Use this for initialization
	void Start () {
        GetComponent<Canvas>().worldCamera = Camera.main;

        text = GetComponentInChildren<Text>();
        text.text = point.ToString();

        Vector2 pos = Camera.main.ScreenToViewportPoint(transform.parent.position)+transform.parent.position;
        if (transform.parent != null) 
        transform.parent = null;

        transform.position = pos;

        transform.position += new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), 0);

        size = new Vector3(StartSize, StartSize, 1);
        transform.localScale = size;
    }
	
	// Update is called once per frame
	void Update () {        
        timer += Time.deltaTime;
        if (timer >= destTime)
        {
            Destroy(gameObject);
        }
        text.color = timer * EndCol + (destTime - timer) * StartCol;
        transform.localScale = timer * Vector3.zero + (destTime - timer) * size;
        transform.rotation = Camera.main.transform.rotation;
    }
    public void SetPoint(int p)
    {
        point = p;
    }
    public void SetPosition(Vector3 v)
    {
        transform.position = v;
    }
}
