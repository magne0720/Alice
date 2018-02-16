using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_VirtualStatusScript : Character{

    public T_TouchScript Ray;

    public enum VirtualStatus 
    {
        NONE,
        HPSTATUS,
        SPEEDSTATUS,
        DELAYSTATUS,
        CANSHOTSTATUS
    }

    VirtualStatus virtualstatus;

    public int VHP;
    public float Vspeed;
    public float Vdelay;
    public bool VcanShot;
    //public GameObject Vbullet;

    public int ChangeHP;
    public float ChangeSpeed;

    bool flg = false;


    // Use this for initialization
    void Start () {

        virtualstatus = VirtualStatus.NONE;

        VHP = HP;
        Vspeed = speed;
        Vdelay = delay;
        VcanShot = canShot;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            switch (virtualstatus)
            {
                case VirtualStatus.NONE:
                    break;
                case VirtualStatus.HPSTATUS:
                    HPStatus(10);
                    break;
                case VirtualStatus.SPEEDSTATUS:
                    SPEEDStatus(1);
                    break;
                case VirtualStatus.DELAYSTATUS:
                    DELAYStatus(0.2f);
                    break;
            }
        }
	}


    //どのステータスを選んでいるか？
    void StatusCheck()
    {
        //HP
        if (Ray.hit.collider.gameObject.name == "HP")
        {
            virtualstatus = VirtualStatus.HPSTATUS;
        }
        //SPEED
        if (Ray.hit.collider.gameObject.name == "SPEED")
        {
            virtualstatus = VirtualStatus.SPEEDSTATUS;
        }
        //DELAY
        if (Ray.hit.collider.gameObject.name == "DELAY")
        {
            virtualstatus = VirtualStatus.DELAYSTATUS;
        }

    }

    //HPのステータス変化
    void HPStatus(int num)
    {
        if (flg == false)
        {
            VHP += num;
            flg = true;
        }
        else
        {
            VHP -= num;
            flg = false;
        }
    }

    //SPEEDのステータス変化
    void SPEEDStatus(float num)
    {
        if (flg == false)
        {
            Vspeed += num;
            flg = true;
        }
        else
        {
            Vspeed -= num;
            flg = false;
        }
    }
    //DELAYのステータス変化
    void DELAYStatus(float num)
    {
        if (flg == false)
        {
            Vdelay += num;
            flg = true;
        }
        else
        {
            Vdelay -= num;
            flg = false;
        }
    }





}
