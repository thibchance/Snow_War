using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartBoutton : MonoBehaviour {
    Button ButtonStart;
    // Use this for initialization
    void Start () {
        Button Clique = ButtonStart.GetComponent<Button>();
        Clique.onClick.AddListener(Load);
    }
    void Load()
    {
        SceneManager.LoadScene("GameLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
