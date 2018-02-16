using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Result : MonoBehaviour
{

    public GameObject[] objs;
    private int count;
    private float timer;
    private bool isPlay;
    
    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isPlay = true;
        }
        if (isPlay)
        {
            timer += Time.deltaTime;
            if (timer >= 0.4f)
            {
                timer = 0;
                objs[count++].GetComponent<N_ResultItem>().StartAnimation();
            }
        }
    }
}