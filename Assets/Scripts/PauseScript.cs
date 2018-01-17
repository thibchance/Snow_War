using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{


    [SerializeField]
    private GameObject panelpause;
    [SerializeField]
    private GameObject uigamepanel;
    private bool isinpause = false;

    //private static Pausemanager instance;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Pause") && !isinpause)
        {
            isinpause = true;
            panelpause.SetActive(true);
            //uigamepanel.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void onresumeGameButtonDown()
    {
        isinpause = false;
        panelpause.SetActive(false);
        //uigamepanel.SetActive(true);
        Time.timeScale = 1;
    }
}
