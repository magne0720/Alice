using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDisplay : MonoBehaviour {
    public Vector2 OffsetPos;
    public float Radius;
    public float waitTime;
    
    float timer;
    Vector2 StartPos;
    Vector2 MidPos;
    Vector2 EndPos;
    bool isMid;
    bool isPlay;
    public enum SCREEN_POINT
    {
        LeftUpper,CenterUpper,RightUpper,LeftCenter,Center,RightCenter,LeftLower,CenterLower,RightLower
    };
    public SCREEN_POINT StartPoint,MidPoint, EndPoint;

	// Use this for initialization
	void Start () {
        timer = 0;
        StartPos = OffsetPos + GetScreenPoint(StartPoint);
        MidPos = OffsetPos + GetScreenPoint(MidPoint);
        EndPos = OffsetPos + GetScreenPoint(EndPoint);
        isMid = false;
        isPlay = false;
        transform.position = OffsetPos+StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                if (timer > waitTime)
                {
                    timer = 0;
                    //isMid ^= true;
                    if (isMid)
                    {
                        isMid = false;
                        isPlay = false;
                    }
                    else
                    {
                        isMid = true;
                    }
                }
                return;
            }
            if (!isMid)
                transform.position = timer * MidPos + (1 - timer) * StartPos;
            else
                transform.position = timer * EndPos + (1 - timer) * MidPos;

            StartPos = OffsetPos + GetScreenPoint(StartPoint);
            MidPos = OffsetPos + GetScreenPoint(MidPoint);
            EndPos = OffsetPos + GetScreenPoint(EndPoint);
        }
    }
    public Vector2 GetScreenPoint(SCREEN_POINT s)
    {
        Vector2 tempPos = new Vector2();
        switch (s)
        {
            case SCREEN_POINT.LeftUpper:
                tempPos = new Vector2(-1, 1);
                break;
            case SCREEN_POINT.CenterUpper:
                tempPos = new Vector2(0, 1);
                break;
            case SCREEN_POINT.RightUpper:
                tempPos = new Vector2(1, 1);
                break;
            case SCREEN_POINT.LeftCenter:
                tempPos = new Vector2(-1, 0);
                break;
            case SCREEN_POINT.Center:
                tempPos = new Vector2(0, 0);
                break;
            case SCREEN_POINT.RightCenter:
                tempPos = new Vector2(1, 0);
                break;
            case SCREEN_POINT.LeftLower:
                tempPos = new Vector2(-1, -1);
                break;
            case SCREEN_POINT.CenterLower:
                tempPos = new Vector2(0, -1);
                break;
            case SCREEN_POINT.RightLower:
                tempPos = new Vector2(1, -1);
                break;
            default:
                tempPos = new Vector2(0, 0);
                break;
        }
        return tempPos*Radius;
    }
    //何秒使うか
    public void Play(float time=2.0f)
    {
        waitTime = time;
        isPlay = true;
    }
    public void Pause()
    {
        isPlay = false;
    }
    public void Stop()
    {
        isPlay = false;
        timer = 0;
    }
}
