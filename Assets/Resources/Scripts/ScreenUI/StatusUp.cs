using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUp: MonoBehaviour {

    const int HPValue = 1000;
    const int POWValue = 30000;
    const int DELAYValue = 50000;

    public float value;

    public VirtualCharactor Vc;
    public Button button;
    public Text text;

    //public T_TouchScript Ray;
    public enum STATUS_TYPE
    {
        HP,DelayRate,PowerRate
    }
    public STATUS_TYPE Type;
   
	// Use this for initialization
	void Start () {

        GameObject vir = GameObject.Find("virtual");
        Vc = vir.GetComponent<VirtualCharactor>();

        text = GetComponentInChildren<Text>();
        button = GetComponentInChildren<Button>();
        
        SetValue(Type);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vc == null)
        {
            GameObject vir = GameObject.Find("virtual");
            Vc = vir.GetComponent<VirtualCharactor>();
        }

        switch (Type)
        {
            case STATUS_TYPE.HP:
                if (Vc.Vscore < value||Vc.Vhp>=Vc.Vmaxhp) button.interactable = false;
                else button.interactable = true;
                break;
            case STATUS_TYPE.DelayRate:
                if (Vc.Vscore < value || Vc.Vdelayrate>=GameManager.GAMEPLAYER_MAXDELAY) button.interactable = false;
                else button.interactable = true;
                break;
            case STATUS_TYPE.PowerRate:
                if (Vc.Vscore < value || Vc.Vpowrate >= GameManager.GAMEPLAYER_MAXPOW) button.interactable = false;
                else button.interactable = true;
                break;
            default:
                break;
        }
        SetValue(Type);
    }
    public void OnClick ()
    {
        switch (Type) {
            case STATUS_TYPE.HP:
                Vc.Vhp += Vc.Vmaxhp/10;
                if (Vc.Vhp >= Vc.Vmaxhp) Vc.Vhp = Vc.Vmaxhp;
                Vc.Vscore -= (int)value;
                break;
            case STATUS_TYPE.DelayRate:
                Vc.Vdelayrate += 0.05f;
                Vc.Vscore -= (int)value;
                break;
            case STATUS_TYPE.PowerRate:
                Vc.Vpowrate += 1.0f; 
                Vc.Vscore -= (int)value;
                break;
        }
        SetValue(Type);
    }
    void SetValue(STATUS_TYPE st)
    {
        bool isMAX = false;
        switch (st)
        {
            case STATUS_TYPE.HP:
                value = HPValue;
                if (Vc.Vhp == Vc.Vmaxhp)
                    isMAX = true;
                break;
            case STATUS_TYPE.PowerRate:
                value = POWValue * Vc.Vpowrate*Vc.Vpowrate;
                if (Vc.Vpowrate >= GameManager.GAMEPLAYER_MAXPOW)
                    isMAX = true;
                break;
            case STATUS_TYPE.DelayRate:
                value = DELAYValue * Vc.Vdelayrate*Vc.Vdelayrate;
                if (Vc.Vdelayrate >= GameManager.GAMEPLAYER_MAXDELAY)
                    isMAX = true;
                break;
            default:
                break;
        }
        value = Mathf.Round(value);
        if (!isMAX)
            text.text = ((int)value).ToString();
        else
            text.text = "MAXValue";

    }
}
