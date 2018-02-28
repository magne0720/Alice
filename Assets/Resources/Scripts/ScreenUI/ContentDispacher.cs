using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentDispacher : MonoBehaviour
{

    public GameObject objs;
    public int TypeNum;
    public enum ShotType
    { 
        Straight, Homing,Special
    }
    public ShotType shotType;

    void Start()
    {


        LoadData(GetName(shotType) + "BulletData");
    }
    void LoadData(string path)
    {
        string temp = Resources.Load("Datas/" + path, typeof(TextAsset)).ToString();

        RectTransform content = GameObject.Find(transform.name).GetComponent<RectTransform>();
        //行分け
        string[] lineText = temp.Split('\n');
        foreach (string line in lineText)
            if (line.StartsWith("#"))
            {
                //コメントアウトの部分なので何もしない
            }
            else
            {
                //カンマ区切り(.CSV) 
                string[] dataText = line.Split(',');
                GameObject item = Instantiate(Resources.Load("Prefabs/MenuItem") as GameObject);
                T_test tt = item.GetComponent<T_test>();

                tt.obj = Resources.Load("Prefabs/" + dataText[0]) as GameObject;
                tt.BulletMoney = int.Parse(dataText[1]);
                tt.SelectNum = (int)shotType;
                item.transform.SetParent(content, false);
            }
    }
    string GetName(ShotType t)
    {
        string temp = "";
        switch (t)
        {
            case ShotType.Straight:
                temp = "Straight";
                break;
            case ShotType.Homing:
                temp = "Homing";
                break;
            case ShotType.Special:
                temp = "Special";
                break;
            default:
                break;
        }
        return temp;
    }
}