using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUp: MonoBehaviour {

    const int HPValue = 1000;
    const int POWValue = 3000;
    const int DELAYValue = 10000;

    public VirtualCharactor Vc;
    public Button Button;

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
                if (Vc.Vscore < HPValue||Vc.Vhp>=Vc.Vmaxhp) Button.interactable = false;
                else Button.interactable = true;
                break;
            case STATUS_TYPE.DelayRate:
                if (Vc.Vscore < DELAYValue || Vc.Vdelayrate>=GameManager.GAMEPLAYER_MAXDELAY) Button.interactable = false;
                else Button.interactable = true;
                break;
            case STATUS_TYPE.PowerRate:
                if (Vc.Vscore < POWValue || Vc.Vpowrate >= GameManager.GAMEPLAYER_MAXPOW) Button.interactable = false;
                else Button.interactable = true;
                break;
            default:
                break;
        }

    }
    public void OnClick ()
    {
        switch (Type) {
            case STATUS_TYPE.HP:
                Vc.Vhp += Vc.Vmaxhp/10;
                if (Vc.Vhp >= Vc.Vmaxhp) Vc.Vhp = Vc.Vmaxhp;
                Vc.Vscore -= HPValue;
                break;
            case STATUS_TYPE.DelayRate:
                Vc.Vdelayrate += 0.05f;
                Vc.Vscore -= DELAYValue;
                break;
            case STATUS_TYPE.PowerRate:
                Vc.Vpowrate += 1.0f; 
                Vc.Vscore -= POWValue;
                break;
        }
    }
}
