using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButtonManager : MonoBehaviour
{
    public GameObject obj;

    public SelectButton OKButton;
    public SelectButton CancelButton;

    public bool isAccept;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckButton(OKButton);
        CheckButton(CancelButton);
    }

    public void CheckButton(SelectButton s)
    {
        //何か押された
        if (s.flg)
        {
            //許可
            if (s.select == SelectButton.Select.OK)
            {
                obj.GetComponent<WeaponButton>().PutWeapon();
            }
            else if(s.select==SelectButton.Select.CANCEL)
            {
                obj.GetComponent<WeaponButton>().Back();
            }
        }
    }
}
