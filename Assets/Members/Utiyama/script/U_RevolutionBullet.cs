using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_RevolutionBullet : Bullet
{
    public GameObject Player;
    public Vector3 target;
    public float angle;
    public float RootSpeed;
    public float Area;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, gameObject.transform.position) > Area|| Vector3.Distance(Player.transform.position, gameObject.transform.position)<Area-0.2f)
        {
            TargetLock();
            transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);

        }
        else
        {
            Vector3 targetPos;
            targetPos = Player.transform.position;
            //transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)), Space.World);
            Vector3 axis = transform.TransformDirection(Vector3.back);
            transform.RotateAround(targetPos, axis, angle * Time.deltaTime);
            //向きの変更
            

        }

        /*target = Player.transform.position;
        
        Vector3 axis = transform.TransformDirection(Vector3.up);
        transform.RotateAround(target,Player.transform.up, 45 * Time.deltaTime);
        */
    }
    void TargetLock()
    {

        ///自分の正面ベクトルをローカルからワールドへ変換
        ///自分から見た敵の方向ベクトルを算出
        Vector3 _ForwardVec = transform.TransformDirection(Vector3.up);
        Vector3 _TargetVec = (Player.transform.position - transform.position);

        ///　自身と敵の角度差・回転速度
        float _Angle = Vector3.Angle(_TargetVec.normalized, _ForwardVec.normalized);
        float _addAngle = (RootSpeed * Time.deltaTime);

        /// 外積

        Vector3 InOrOut = Vector3.Cross(_ForwardVec, _TargetVec);
        float cross = _ForwardVec.x * _TargetVec.y - _TargetVec.x * _ForwardVec.y;
        /// 内側か外側か（右か左か）
        int _IOO = cross > 0 ? 1 : -1;
        ///
        gameObject.transform.Rotate(0, 0, _IOO * _addAngle);
    }
}
