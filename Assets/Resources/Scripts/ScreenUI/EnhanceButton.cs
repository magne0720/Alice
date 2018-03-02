using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceButton : MonoBehaviour {

    public VirtualCharactor Vc;
    public Character Char; 
    public Select select;

		public enum Select
    {
        Enhance,Restore,Buy,Buck
    }

    GameObject vir;
    GameObject WeaponButton;
    GameObject Chara;

	// Use this for initialization
	void Start () {
        //オブジェクト参照
        vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();
        Chara = GameObject.Find("honke");
        Char = Chara.GetComponent<Character>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Onclick()
    {
        switch(select)
        {
            case Select.Enhance:
                Char.MAX_HP = Vc.Vmaxhp;
                Char.HP = Vc.Vhp;
                Char.powRate = Vc.Vpowrate;
                Char.delayRate = Vc.Vdelayrate;
                Char.score = Vc.Vscore;
                break;
            case Select.Restore:
                Vc.Vmaxhp = Char.MAX_HP;
                Vc.Vhp = Char.HP;
                Vc.Vpowrate = Char.powRate;
                Vc.Vdelayrate = Char.delayRate;
                Vc.Vscore = Char.score;
                Vc.VBullets = Char.Bullets;
                break;
        }
    }
}
