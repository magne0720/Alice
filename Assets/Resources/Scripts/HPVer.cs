using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPVer : MonoBehaviour {

    public Character character;

    public Slider slider;
    public Text HPnum;


    // Use this for initialization
    void Start()
    {

        slider.maxValue = character.HP;
        HPbar();
    }

    // Update is called once per frame
    void Update()
    {

        HPbar();

        if (character != null)
        {
            transform.position = character.transform.position + new Vector3(0, 1, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //EnemyのHPゲージと数字
    void HPbar()
    {

        slider.value = character.HP;
        if(HPnum!=null)
        HPnum.text = character.HP.ToString();
    }
    public void SetCharacter(Character c)
    {
        character = c;
    }
}
