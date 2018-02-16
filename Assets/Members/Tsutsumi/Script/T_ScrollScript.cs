using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class T_ScrollScript : MonoBehaviour
{

    public RectTransform HPprefab = null;
    public RectTransform Speedprefab = null;


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            var hpitem = GameObject.Instantiate(HPprefab) as RectTransform;
            hpitem.SetParent(transform, false);
        }
        for (int i = 0; i < 3; i++)
        {
            var speeditem = GameObject.Instantiate(Speedprefab) as RectTransform;
            speeditem.SetParent(transform, false);
        }
    }
}