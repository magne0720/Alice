using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public VirtualCharactor Vc;
    public Text Score;

	// Use this for initialization
	void Start () {

        GameObject vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();
    }
	
	// Update is called once per frame
	void Update () {
        Score.text = ("Score  ") + Vc.Vscore.ToString();
    }
}
