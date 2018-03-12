using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Result : MonoBehaviour
{
    public GameObject TitleButton;
    public GameObject[] objs;
    private int count;
    private float timer;
    private bool isPlay;
    
    // Use this for initialization
    void Start()
    {
        timer = 0;
        TitleButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            timer += Time.deltaTime;
            if (timer >= 0.4f)
            {
                timer = 0;
                if (count >= objs.Length)
                {
                    StopDisp();
                    TitleButton.SetActive(true);
                    return;
                }
                objs[count++].GetComponent<N_ResultItem>().StartAnimation();
            }
        }
    }
    public void StartDisp()
    {
        isPlay = true;
    }
    public void StopDisp()
    {
        isPlay = false;
    }
    public void Reset()
    {
        foreach(GameObject g in objs)
        {
            g.GetComponent<N_ResultItem>().Reset();
        }
        timer = 0;
        count = 0;
        TitleButton.SetActive(false);

    }
}