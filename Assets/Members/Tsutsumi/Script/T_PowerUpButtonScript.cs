using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PowerUpButtonScript : MonoBehaviour {

    public T_VirtualCharactorScript Vc;
    public Button HPButton;
    public Button DelayButton;
    public Button PowerButton;

    //public T_TouchScript Ray;
    public enum WhichButton
    {
        HP,DelayRate,PowerRate
    }
    public WhichButton Button;
   
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vc.Vscore < 1000) HPButton.interactable = false;
        else HPButton.interactable = true;

        if (Vc.Vscore < 3000) DelayButton.interactable = false;
        else DelayButton.interactable = true;

        if (Vc.Vscore < 10000) PowerButton.interactable = false;
        else PowerButton.interactable = true;
    }
    public void OnClick ()
    {
        switch (Button) {
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
