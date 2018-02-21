using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_CanvasGroup : MonoBehaviour {

    CanvasGroup group;

    public float roopTime;//1往復分の時間
    //public float waitTime;//完全表示時間
    public bool reverse;//逆再生
    private float timer;//タイマー
    private bool isPlay;//再生中か

    // Use this for initialization
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        isPlay = true;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            StartMask(true);
        }
        if (Input.GetKey(KeyCode.H))
        {
            StartMask(false);
        }
        if (!isPlay)
        {
            return;
        }
        MaskCut();
    }

    void MaskCut()
    {
        if (roopTime <= 0)
        {
            //0割り算を回避
            roopTime = 1.0f;
        }
        timer += Time.deltaTime;
        if (timer > roopTime)
        {
            timer = 1.0f;
            StopMask();
        }
        //途中まで
        // 現在の表示アルファレベル=分割数 * 時間経過 / 全体の時間
        //途中から
        // 現在の表示アルファレベル=時間ずれ - 分割数 * 時間経過 / 全体の時間
        if (reverse)
        {
            group.alpha = 1.0f - timer / roopTime;
        }
        else
        {
            group.alpha = timer / roopTime;
        }
    }

    public void StartMask(bool isReverse = false, float roop = 0.0f)
    {
        reverse = isReverse;
        isPlay = true;
        timer = 0;
        if (roop != 0)
        {
            roopTime = roop;
        }
    }

    public void PauseMask()
    {

    }

    public void StopMask()
    {
        isPlay = false;
    }
}
