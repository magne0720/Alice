﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_HomeBaseUI : MonoBehaviour {

    public N_Character CharactorScript;

    public Slider slider;
    //public Text HPnum;

    // Use this for initialization
    void Start () {
        slider.maxValue = CharactorScript.HP;
        //HPnum.text = CharactorScript.HP.ToString();
    }
	
	// Update is called once per frame
	void Update () {


        HPbar();

    }

    void HPbar()
    {

        slider.value = CharactorScript.HP;
        //HPnum.text = CharactorScript.HP.ToString();
    }
}
