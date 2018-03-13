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
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                isLoad = true;
                playerStatus = player.GetComponent<Character>();
            }
        }
        else
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
    public void OnClick()
    {
        playerStatus.ChangeEquip(Type);
    }
}
