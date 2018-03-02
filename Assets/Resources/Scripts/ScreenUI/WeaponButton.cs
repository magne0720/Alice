using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour {


    VirtualCharactor Vc;
    ContentDispacher Cd;


    public GameObject obj;
    public int BulletMoney; //武器にかかる費用
    public GameObject enhanceUI;
    public GameObject instanceUI;

    private GameObject vir;


    bool flg = false;
    public int SelectNum;

	// Use this for initialization
	void Start () {
        //オブジェクト参照
        vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Onclick()
    {
        if (flg == false)
        {
            if (instanceUI == null)
            {
                instanceUI = GameObject.Instantiate(enhanceUI) as GameObject;
                SelectButton Sb = instanceUI.GetComponent<SelectButton>();
                Sb.Vc = Vc;
                //Ts. = this;
            }
        }
        if (flg == true)
        {
            Vc.VBullets[SelectNum] = obj;
        }
    }
    //武器を買う、武器を装備
    public void PutWeapon()
    {
        if (flg == false && Vc.Vscore >= BulletMoney)
        {
            Vc.Vscore -= BulletMoney;
            flg = true;
        }
        if (flg == true)
        {
            //タブごとに入れる場所
            Vc.VBullets[SelectNum] = obj;
        }
    }
}
