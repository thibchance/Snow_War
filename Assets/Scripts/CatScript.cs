using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

   

    
    
    private bool touchPlayer =  false;
    [SerializeField] Transform Player;
    [SerializeField] Transform spawnflee;
    [SerializeField] float movespeed = 1f;
    [SerializeField] float speedflee = 1f;
   
	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, movespeed * Time.deltaTime);

        if (touchPlayer)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, spawnflee.transform.position, speedflee * Time.deltaTime);

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchPlayer = true;
        }
    }
}
