using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttondirection : MonoBehaviour
{

    public void ButtonStart()
    {

        SceneManager.LoadScene("GameLevel");

    }

    public void ButtonCredit()
    {
        SceneManager.LoadScene("CreditMenu");
    }
    public void ButtonRetour()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
	
