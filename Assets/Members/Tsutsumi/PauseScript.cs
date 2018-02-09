using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{

    [SerializeField]
    //　ポーズした時に表示するUI
    private GameObject pauseUI;
    //　ポーズUIのインスタンス
    private GameObject instancePauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (instancePauseUI == null)
            {
                instancePauseUI = GameObject.Instantiate(pauseUI) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(instancePauseUI);
                Time.timeScale = 1f;
            }
        }
    }
}