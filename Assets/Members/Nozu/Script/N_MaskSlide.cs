using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_MaskSlide : MonoBehaviour
{
    public Sprite BaseTexure;//元の画像
    public SpriteMask SM_IN;//表示傾向
    public SpriteMask SM_OUT;//非表示傾向
    
    public float roopTime;//1往復分の時間
    //public float waitTime;//完全表示時間
    public bool reverse;//逆再生
    private float timer;//タイマー

    // Use this for initialization
    void Start()
    {
        timer = 0;
        SpriteRenderer Sr= GetComponent<SpriteRenderer>();
        if (Sr.sprite == null)
        {
            Sr.sprite = BaseTexure;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roopTime <= 0)
        {
            //0割り算を回避
            roopTime = 1.0f;
        }

        //途中まで
        // 現在の表示アルファレベル=分割数 * 時間経過 / 全体の時間
        //途中から
        // 現在の表示アルファレベル=時間ずれ - 分割数 * 時間経過 / 全体の時間
        if (reverse)
        {
            SM_IN.alphaCutoff = 2.0f - 2.0f * timer / roopTime;
            //SM_IN.alphaCutoff = Mathf.Sin(2 * Mathf.PI * (timer + range));
            SM_OUT.alphaCutoff = 2.0f * timer / roopTime;
            //SM_OUT.alphaCutoff = Mathf.Sin(2 * Mathf.PI * (1-timer + range));
        }
        else
        {
            SM_IN.alphaCutoff = 2.0f * timer / roopTime;
            SM_OUT.alphaCutoff = 2.0f - 2.0f * timer / roopTime;
        }
        timer += Time.deltaTime;
        if (timer > roopTime)
            timer = 0;
    }
}
