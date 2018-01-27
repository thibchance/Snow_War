using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoyScript : MonoBehaviour {

    [SerializeField] Transform Player;
   
    [SerializeField] float movespeed = 1f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, movespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "move")
        {
            movespeed++;
        }
    }
}
