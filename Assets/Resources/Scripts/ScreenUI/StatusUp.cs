using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUp: MonoBehaviour {

    public VirtualCharactor Vc;
    public Button Button;

    //public T_TouchScript Ray;
    public enum WhichButton
    {
        HP,DelayRate,PowerRate
    }
    public WhichButton Type;
   
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vc.Vscore < 1000) Button.interactable = false;
        else Button.interactable = true;

        if (Vc.Vscore < 3000) Button.interactable = false;
        else Button.interactable = true;

        if (Vc.Vscore < 10000) Button.interactable = false;
        else Button.interactable = true;
    }
    public void OnClick ()
    {
        switch (Type) {
            case WhichButton.HP:
                Vc.Vhp += 10;
                Vc.Vscore -= 1000;
                break;
            case WhichButton.DelayRate:
                Vc.Vdelayrate += 0.05f;
                Vc.Vscore -= 3000;
                break;
            case WhichButton.PowerRate:
                Vc.Vpowrate += 0.02f; 
                Vc.Vscore -= 10000;
                break;
        }
        
    }
}
