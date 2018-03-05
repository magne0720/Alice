using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public VirtualCharactor Vc;
    public Character Player;
    public SelectButtonManager Sb;
    public Button Button;


    public GameObject obj;
    public int BulletMoney; //武器にかかる費用
    public GameObject enhanceUI;
    public GameObject instanceUI;

    private GameObject vir;


    public bool openFlg;
    public int SelectNum;
    private Text price;
    public Image BulletImage;
    public string ImagePath;

    // Use this for initialization
    void Start()
    {
        //オブジェクト参照
        vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();

        Button = GetComponent<Button>();

        price = GetComponentInChildren<Text>();
        price.text = BulletMoney.ToString();

        BulletImage.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;

        openFlg = (BulletMoney == 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (!openFlg)
        {
            if (Vc.Vscore < BulletMoney)
            {
                Button.interactable = false;
                BulletImage.color = new Color(0, 0, 0, 0.5f);
            }
            else
            {
                Button.interactable = true;
                BulletImage.color = new Color(0, 0, 0, 1);
            }
        }
        else
        {
            BulletImage.color = new Color(1, 1, 1, 1);
        }
    }
    public void Onclick()
    {
        if (openFlg == false)
        {
            if (instanceUI == null)
            {
                instanceUI = GameObject.Instantiate(enhanceUI) as GameObject;
                Sb = instanceUI.GetComponent<SelectButtonManager>();
                Sb.obj = gameObject;
            }
        }
        else
        {
            Vc.VBullets[SelectNum] = obj;
        }
    }
    //武器を買う、武器を装備
    public void PutWeapon()
    {
        Destroy(instanceUI);
        if (openFlg == false && Vc.Vscore >= BulletMoney)
        {
            Vc.Vscore -= BulletMoney;
            Player.score -= BulletMoney;
            openFlg = true;
        }
        if (openFlg == true)
        {
            //タブごとに入れる場所
            Vc.VBullets[SelectNum] = obj;
        }
    }
    public void Back()
    {
        Destroy(instanceUI);
    }
    public void SetSprite(string path)
    {
        BulletImage.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }
}
