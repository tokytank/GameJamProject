using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisp : MonoBehaviour
{   
    public static EnergyDisp energyDisp;
    Image Bar;
    public EnergyControl energyControl;
    

    private void Awake() {
        energyDisp = this;
    }
    void Start() {
        Bar = GetComponent<Image>();
    }

    void Update() {
        Bar.fillAmount = energyControl.energy / 100;
    }
}
