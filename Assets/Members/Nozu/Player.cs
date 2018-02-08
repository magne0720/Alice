using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nozu
{

    public class Player : Character
    {
        Vector3 lastTarget;
        public Vector3 shotTarget;
        bool isTouch;

        //玉射出の方向
        Vector3 mouseStartPosition = new Vector3();
        Vector3 mouseDragPosition = new Vector3();

        // Use this for initialization
        void Start()
        {
            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();

            target = Vector3.zero;
            if (Input.GetKey(KeyCode.D))//→
            {
                target.x += 1;
            }
            if (Input.GetKey(KeyCode.W))//↑
            {
                target.y += 1;
            }
            if (Input.GetKey(KeyCode.A))//←
            {
                target.x -= 1;
            }
            if (Input.GetKey(KeyCode.S))//↓
            {
                target.y -= 1;
            }
            //移動中かどうか
            if (target.magnitude!= 0)
            {
                lastTarget = target;
                canShot = true;
            }
            else
            {
                canShot = false;
            }
            //位置の更新
            transform.position += target*speed*Time.deltaTime;


            //最初のタッチ位置
            if (Input.GetMouseButtonDown(0))
            {
                mouseStartPosition = Input.mousePosition;
                Debug.Log("start="+mouseStartPosition);
                isTouch = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //mouseStartPosition = Vector3.zero;
                isTouch = false;
            }
            //ドラッグしてる間
            if (isTouch)
            {
                Debug.Log("Drag," + mouseDragPosition);
                mouseDragPosition = Input.mousePosition;
            }
            Vector3 shotPos = mouseDragPosition - mouseStartPosition;
            Debug.Log("shot=" + shotPos);

            // 移動方向を取得する
            Rigidbody2D rd = GetComponent<Rigidbody2D>();
            Vector2 v = rd.velocity;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-shotPos.x, shotPos.y) * Mathf.Rad2Deg);

            timer += Time.deltaTime;
            if (timer>=delay&&canShot)
            {
                timer = 0;
                Instantiate(bullet,transform.position,transform.rotation);
            }
        }
    }
}