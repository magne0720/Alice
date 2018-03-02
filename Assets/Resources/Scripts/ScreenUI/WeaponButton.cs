using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public VirtualCharactor Vc;
    ContentDispacher Cd;
    public SelectButtonManager Sb;
    public Button Button;


    public GameObject obj;
    public int BulletMoney; //武器にかかる費用
    public GameObject enhanceUI;
    public GameObject instanceUI;

    private GameObject vir;


    bool flg = false;
    bool test = false;
    public int SelectNum;

    // Use this for initialization
    void Start()
    {
        //オブジェクト参照
        vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();

        Button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!flg)
        if (Vc.Vscore < BulletMoney) Button.interactable = false;
        else Button.interactable = true;

    }
    public void Onclick()
    {
        if (flg == false)
        {
            if (instanceUI == null)
            {
                instanceUI = GameObject.Instantiate(enhanceUI) as GameObject;
                Sb = instanceUI.GetComponent<SelectButtonManager>();
                Sb.obj = gameObject;
            }
        }
        else
        {
            Vc.VBullets[SelectNum] = obj;
        }
    }
    //武器を買う、武器を装備
    public void PutWeapon()
    {
        Destroy(instanceUI);
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
    public void Back()
    {
        Destroy(instanceUI);
    }
}
