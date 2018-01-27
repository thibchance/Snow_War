using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBar : MonoBehaviour {


    [SerializeField] float Energy;

    [SerializeField] float energymax = 2;

    [SerializeField] GameObject EnergyBar;

    [SerializeField] float EnergiLimit= 100;

    [SerializeField] Image imagebar;
    
	// Use this for initialization
	void Start ()
    {
       //GetComponent<SpriteRenderer>().color = Color.clear;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float calculateenergy = Energy + energymax;
       
        /*if (Energy < EnergiLimit)
        {
            imagebar.fillAmount = Energy + energymax;

            SetEnergyBar(calculateenergy);
        }
        if ( Energy == EnergiLimit)
        {
            //active l'attaque speciale
            Energy = 0;
        }*/
    }

    public void SetEnergyBar(float myEnergy)
    {
        //EnergyBar.transform.localScale = new Vector3(EnergyBar.transform.localScale.x, myEnergy, EnergyBar.transform.localScale.z);
        //Energy += energymax;
        //WinEnergy();

    }

    public void WinEnergy()
    {
        Energy++;
        imagebar.fillAmount = Energy/EnergiLimit;
        Debug.Log(Energy);
    }
}
