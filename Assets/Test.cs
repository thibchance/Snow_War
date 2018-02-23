using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private PlayerScript playerScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseEnter()
    {
        Debug.Log("I am over something");
        playerScript.mouseRight = true;
    }
}
