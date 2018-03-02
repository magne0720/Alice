using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_ResultItem : MonoBehaviour {

    public GameObject ScriptObj;
    public Text label;
    private int value;
    public float speed;
    public float startDelay;
    private float timer;
    private bool isPlay;
    private Vector3 start, end;

    public enum RESULT_TYPE
    {
        NONE,   SCORE,KILL,HOME
    }
    public RESULT_TYPE type;
    // Use this for initialization
    void Start ()
    {
        isPlay = false;
        start = transform.position + new Vector3(20, 0, 0);
        end = transform.position;
        transform.position = timer * end + (1 - timer) * start;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K)) isPlay = true;

        if(isPlay)
        Animation();
    }


    void Animation()
    {
        timer += Time.deltaTime*speed;

        float calcTimer = timer - startDelay;

        if (calcTimer<=0)
        {
            return;
        }
        if (calcTimer >= 1.0f)
        {
            calcTimer = 1.0f;
            timer = 0;
            isPlay = false;
        }

        transform.position = calcTimer * end + (1 - calcTimer) * start;

    }

    public void StartAnimation()
    {
        isPlay = true;
        SetStatusTarget();
    }
    public void StopAnimation()
    {
        isPlay = false;
    }

    public void Setvalue(int val)
    {
        value = val;
    }
    public void Reset()
    {
        isPlay = false;
        transform.position = start;
    }
    void SetStatusTarget()
    {
        switch (type)
        {
            case RESULT_TYPE.NONE:
                break;
            case RESULT_TYPE.SCORE:
                value = GameManager.playerStatus.score;
                break;
            case RESULT_TYPE.KILL:
                value = GameManager.KilledValue;
                break;
            case RESULT_TYPE.HOME:
                break;
            default:
                break;
        }
        label.text = value.ToString();
    }
}
