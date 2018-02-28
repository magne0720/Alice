using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_test : MonoBehaviour {

    VirtualCharactor Vc;
    ContentDispacher Sc;


    public GameObject obj;
    public int BulletMoney; //武器にかかる費用
    public GameObject enhanceUI;
    public GameObject instanceUI;

    //private TextAsset textasset;
    //private string game;
    //private string[] games;
    //private int loadtext;



    private GameObject vir;


    bool flg = false;
    public int SelectNum;


	// Use this for initialization
	void Start () {

    //game = (Resources.Load("Datas/BulletData",typeof(TextAsset)) as TextAsset).text;
    //    games = game.Split(char.Parse("\n"));


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
                SelectButton Ts = instanceUI.GetComponent<SelectButton>();
                Ts.Vc = Vc;
                //Ts = this;
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
