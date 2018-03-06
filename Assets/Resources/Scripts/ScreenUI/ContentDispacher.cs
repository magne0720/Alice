using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ContentDispacher : MonoBehaviour
{
    public int TypeNum;
    public enum ShotType
    { 
        Straight, Homing, Special
    }
    public ShotType shotType;
    public List<WeaponButton> Items;

    void Start()
    {
        LoadData(GetName(shotType) + "BulletData");
    }
    void LoadData(string path)
    {
        int count = 0;
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
                WeaponButton Wb = item.GetComponent<WeaponButton>();
                
                Wb.BulletObj = Resources.Load("Prefabs/Bullets/" + dataText[0]) as GameObject;
                Wb.BulletMoney = int.Parse(dataText[1]);
                //改行(ここではSplitで置き換える'\r')を削除する必要がある                
                //string str = "Textures/" + dataText[2].Replace('\r', '\0');
                Wb.ImagePath = "Textures/" + dataText[2].Replace("\r","");
                Wb.TypeNum = (int)shotType;
                Wb.ContentNum = count++;

                item.transform.SetParent(content, false);
                Items.Add(Wb);
            }
        //初期値は0番目装備
        SetEquip(0);
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
    public void ItemResset()
    {
        foreach (WeaponButton w in Items)
        {
            if(w.BulletMoney!=0)
            w.openFlg = false;
        }
        //初期値は0番目装備
        SetEquip(0);
    }
    public void ResetPosition()
    {
        //transform.position = new Vector3(0, transform.position.y,0);
    }
    public void SetEquip(int num)
    {
        int count = 0;
        foreach(WeaponButton w in Items)
        {
            if (num == count) {
                w.SetEquip(true);
            }else
            {
                w.SetEquip(false);
            }
            count++;
        }
    }
}