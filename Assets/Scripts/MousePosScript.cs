using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosScript : MonoBehaviour {



	// Use this for initialization
	void Start ()
    {
        //Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //rotation.z = 0;
        //transform.right = rotation;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
