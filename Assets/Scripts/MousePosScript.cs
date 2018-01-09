using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosScript : MonoBehaviour {



	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation.z = 0;
        transform.right = rotation;
    }
}
