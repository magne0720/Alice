using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_StatusButtonScript : MonoBehaviour
{

    public T_VirtualCharactorScript Char;
    public T_PowerUpButtonScript PowerUp;
    public Slider slider;
    //public T_TouchScript Ray;

    public enum VirtualStatus
    {
        NONE,
        HPSTATUS,
        POWERRATESTATUS,
        DELAYRATESTATUS,
    }

    public VirtualStatus virtualstatus;

    public float value;

    bool flg = false;

    // Use this for initialization
    void Start()
    {
        switch (virtualstatus)
        {
            case VirtualStatus.NONE:
                break;
            case VirtualStatus.HPSTATUS:
                slider.maxValue = Char.Vmaxhp;
                break;
            case VirtualStatus.POWERRATESTATUS:
                slider.maxValue = 2.0f;
                //slider.maxValue = 10;//Char.Max_Speed;
                break;
            case VirtualStatus.DELAYRATESTATUS:
                slider.maxValue = 2.0f;
                //slider.maxValue = 10;//Char.delay;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeValue();
        switch (virtualstatus)
        {
            case VirtualStatus.NONE:
                break;
            case VirtualStatus.HPSTATUS:
                value = Char.Vhp;
                break;
            case VirtualStatus.POWERRATESTATUS:
                value = Char.Vpowrate;
                break;
            case VirtualStatus.DELAYRATESTATUS:
                value = Char.Vdelayrate;
                break;
        }
    }
    void ChangeValue()
    {
                slider.value = value;
    }
}