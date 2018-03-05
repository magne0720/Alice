using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{

    public VirtualCharactor Char;
    public StatusUp PowerUp;
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
        SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Char == null)
        {
            GameObject vir = GameObject.Find("virtual");
            Char = vir.GetComponent<VirtualCharactor>();
        }

        SetStatus();
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
    void SetStatus()
    {
        switch (virtualstatus)
        {
            case VirtualStatus.NONE:
                break;
            case VirtualStatus.HPSTATUS:
                slider.maxValue = GameManager.GAMEPLAYER_MAXHP;
                break;
            case VirtualStatus.POWERRATESTATUS:
                slider.maxValue = GameManager.GAMEPLAYER_MAXPOW;
                //slider.maxValue = 10;//Char.Max_Speed;
                break;
            case VirtualStatus.DELAYRATESTATUS:
                slider.maxValue = GameManager.GAMEPLAYER_MAXDELAY;
                //slider.maxValue = 10;//Char.delay;
                break;
        }
    }
}