using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGameButton : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick(int mode)
    {
        FindObjectOfType<GameManager>().GameStart(mode);
    }
}
