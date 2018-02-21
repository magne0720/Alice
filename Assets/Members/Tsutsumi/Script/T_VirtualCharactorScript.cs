using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_VirtualCharactorScript : MonoBehaviour {

    public Player Char;
    public int Vmaxhp;
    public int Vhp;
    public float Vpowrate;
    public float Vdelayrate;
    public int Vscore;

	// Use this for initialization
	void Start () {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vmaxhp = Char.MAX_HP;
        Vpowrate = Char.powRate;
        Vdelayrate = Char.delayRate;
        Vscore = Char.score;
	}
	
	// Update is called once per frame
	void Update () {
        Vhp = Char.HP;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Char.HP--;
        };
    }
}
