using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

    public EnemySc EnemyScript;

    public Slider slider;
    public Text HPnum;


	// Use this for initialization
	void Start () {
        slider.maxValue = EnemyScript.EnemyHP;
        HPnum.text = EnemyScript.EnemyHP.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        HPbar();

    }

    //EnemyのHPゲージと数字
    void HPbar()
    {

            slider.value = EnemyScript.EnemyHP;
            HPnum.text = EnemyScript.EnemyHP.ToString();
    }
}
