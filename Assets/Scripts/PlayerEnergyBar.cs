using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyBar : MonoBehaviour {


    [SerializeField]
    float Energy;
    [SerializeField]
    float energymax = 2;
    [SerializeField]

    GameObject EnergyBar;
    [SerializeField]
    float EnergiLimit= 100;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    
        if (Energy < EnergiLimit)
        {
            float calculateEnergy = Energy + energymax;
            SetEnergyBar(calculateEnergy);
        }
        if ( Energy == EnergiLimit)
        {
            //active l'attaque speciale
            Energy = 0;
        }

    }

    public void SetEnergyBar(float myEnergy)
    {
        EnergyBar.transform.localScale = new Vector3(EnergyBar.transform.localScale.x, myEnergy, EnergyBar.transform.localScale.z);
    }

    public void WinEnergy()
    {
        Energy++;
    }
}
