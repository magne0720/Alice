using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_GameManager : MonoBehaviour {

    public GameObject player;
    private Character playerStatus;
    public GameObject title; 

    public bool isPlay;

	// Use this for initialization
	void Start () {
        isPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPlay && Input.GetKeyDown(KeyCode.X))
        {
            isPlay = true;
            GameObject g=Instantiate(player,new Vector3(0,-4,0),new Quaternion());
            playerStatus = g.GetComponent<Character>();//プレイヤーとしてみるオブジェクトを登録
            title.SetActive(false);
        }
        if (isPlay&&playerStatus.HP <= 0 )
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isPlay = false;
        title.SetActive(true);
    }
}
