using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnowballPlayer")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigSnowBall")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Wave")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SnowballEnemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
