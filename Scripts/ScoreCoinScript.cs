using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoinScript : MonoBehaviour {


    private GameManager gameManager;
    private int ScoreCoin = 100;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            gameManager.score = gameManager.score + ScoreCoin;
        }
    }
}
