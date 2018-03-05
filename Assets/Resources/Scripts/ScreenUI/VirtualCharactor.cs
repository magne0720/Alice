using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCharactor : MonoBehaviour {

    public Character Char;
    public int Vmaxhp;
    public int Vhp;
    public float Vpowrate;
    public float Vdelayrate;
    public int Vscore;
    public GameObject[] VBullets;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vhp = Char.HP;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Char.HP--;
        };
    }
    public void SetPlayer(Character c)
    {

        Vmaxhp = c.MAX_HP;
        Vhp = c.HP;
        Vpowrate = c.powRate;
        Vdelayrate = c.delayRate;
        Vscore = c.score;
        VBullets = c.Bullets;
    }
}
