using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    Text score;
    public Character player;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            score.text = player.score.ToString();
        }
    }
    public void SetPlayer(Character p)
    {
        player = p;
    }
}
