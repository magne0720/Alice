using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_TouchScript : MonoBehaviour {

    // rayが届く範囲
    public float distance = 100f;
    public Ray ray;
    public RaycastHit2D hit;
    public int layerMask;

    // Use this for initialization
    void Start () {
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //レイヤーマスク作成
        layerMask = LayerMask.GetMask(new string[] { "TapUI" });


        hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, distance, layerMask);
		
	}
    void Update()
    {
        // 左クリックを取得
        if (Input.GetMouseButtonDown(0))
        {
            //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //レイヤーマスク作成
            layerMask = LayerMask.GetMask(new string[] { "TapUI" });


            hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, distance, layerMask);

            //Debug.Log(hit.collider.gameObject.name);
        }
    }
}
