using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float MaxHealth = 10;
    public float Health;

    public GameObject healthBar;

	// Use this for initialization
	void Start ()
    {
        Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		float calculateHealth = Health / MaxHealth;
        SetHealthBar(calculateHealth);

        if(Health <=0)
        {
            Health = 0;
            SceneManager.LoadScene("LooseMenu");
        }
	}

    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void LoseLife()
    {
        Health--;
    }
}
