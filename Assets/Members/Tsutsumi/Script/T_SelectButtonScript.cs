using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_SelectButtonScript : MonoBehaviour {

    public T_VirtualCharactorScript Vc;
    public Character Char; 

		public enum Select
    {
        Enhance,Restore
    }

    public Select select;

	// Use this for initialization
	void Start () {

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
                break;
        }
    }
}
