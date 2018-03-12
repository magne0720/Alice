using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour {

   public GameObject player;
    public int Type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void OnClick()
    {
        player.transform.GetComponent<Player>().ChangeEquip(Type);
    }
}
