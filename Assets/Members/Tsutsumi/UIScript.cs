using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

    public Character CharactorScript;

    public Slider slider;
    public Text HPnum;


	// Use this for initialization
	void Start () {
        slider.maxValue = CharactorScript.HP;
        HPnum.text = CharactorScript.HP.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        HPbar();

    }

    //EnemyのHPゲージと数字
    void HPbar()
    {

            slider.value = CharactorScript.HP;
            HPnum.text = CharactorScript.HP.ToString();
    }
}
