using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour {

   public GameObject player;
    private Character playerStatus;
    public Image image;
    public int Type;
    bool isLoad;

	// Use this for initialization
	void Start () {
        isLoad = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isLoad)
        {
            SetPlayer();
        }
        else
        {
            if (player != null)
            {
                if (playerStatus.GetCurrentBulletNum() == Type)
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }
            }
        }
    }
    public void OnClick()
    {
        SetPlayer();
        if (player != null)
        {


            playerStatus.ChangeEquip(Type);
            if (playerStatus.GetCurrentBulletNum() == Type)
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
        }
    }
    void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        if (player != null)
        {
            isLoad = true;
            playerStatus = player.GetComponent<Character>();
            if (playerStatus.GetCurrentBulletNum() == Type)
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
        }
    }
}
