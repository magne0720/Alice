using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour {

    public const float PI = 3.14159274f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static float Length(Vector3 p)
    {
        return Mathf.Sqrt(p.x * p.x + p.y * p.y + p.z * p.z);
    }


    //内積
    public static float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }
    //内積
    public static float Dot(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    //外積
    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        Vector3 c;

        c.x = a.y * b.z - a.z * b.y;
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;

        return c;
    }
    public static float Cross2D(Vector2 a, Vector2 b)
    {
        return ((a.x * b.y) - (a.y * b.x));
    }

    //内積(単位はラジアン)
    public static float Dot2D(Vector2 from, Vector2 to)
    {
        return ((from.x * to.x) + (from.y * to.y));
    }

    //外積
    public static float cross(Vector2 from, Vector2 to)
    {
        return ((from.x * to.y) - (from.y * to.x));
    }

    //デグリをラジアンに変換する(単位はΠ)
    public static float degToRag(float deg)
    {
        //ラジアン = 度 × 円周率 ÷ 180
        return deg * PI / 180;
    }

    //ラジアンをデグリに変換する(単位は度)
    public static float ragToDeg(float rag)
    {
        //度 = ラジアン × 180 ÷ 円周率
        return rag * 180 / PI;
    }

    //方向ベクトルから時計回りに固有角度で自身の視認範囲のベクトルを取得する
    public static Vector3 getDirectionDegree(Vector3 target, float deg, float range = 1.0f)
    {
        Vector3 vector = target.normalized;
        //ラジアンに変換
        float rag = degToRag(deg);

        float ax = vector.x * Mathf.Cos(rag) - vector.y * Mathf.Sin(rag);
        float ay = vector.x * Mathf.Sin(rag) + vector.y * Mathf.Cos(rag);

        vector.x = ax * range;
        vector.y = ay * range;

        return vector;
    }
    public static Vector2 GetRotateVector(Vector2 pos,Vector2 target,int rate)
    {
        Vector2 temp = new Vector2();
        int mag = 0;

        if (target.x == 0) return pos;

        mag = (target.x > 0) ? -1 : 1;

       temp = getDirectionDegree(pos, mag*rate);

        return temp;
    }
}
