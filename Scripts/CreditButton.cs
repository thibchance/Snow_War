using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour {
    Button ButtonCredit;
    // Use this for initialization
    void Start()
    {
        Button Clique = ButtonCredit.GetComponent<Button>();
        Clique.onClick.AddListener(Load);
    }
    void Load()
    {
        SceneManager.LoadScene("CreditScene");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
