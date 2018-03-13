using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGameButton : MonoBehaviour {

    Button button;
    public GameObject pass;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart(int mode)
    {
        FindObjectOfType<GameManager>().GameStart(mode);
        pass.SetActive(false);
    }
    public void DispPass()
    {
        pass.SetActive(true);
    }
}
