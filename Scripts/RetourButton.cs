using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetourButton : MonoBehaviour {
    Button ButtonRetour;
    // Use this for initialization
    void Start()
    {
        Button Clique = ButtonRetour.GetComponent<Button>();
        Clique.onClick.AddListener(Load);
    }
    void Load()
    {
        SceneManager.LoadScene("StartMenue");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
