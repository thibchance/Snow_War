using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour {



    [SerializeField]
    Transform Player;
    [SerializeField]
    Transform Spawnfuite;
    [SerializeField]
    float movespeed = 1f;
    //[Header("raycast")]
    //[SerializeField]
    //Transform positionraycast;
    //[SerializeField]
    //float radiusraycast;
    //[SerializeField]
    //LayerMask layermask;

    
	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        //bool touch = Physics2D.OverlapCircle(positionraycast.position, radiusraycast, layermask);
        //if (touch)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, Spawnfuite.position, movespeed * Time.deltaTime);
        //}
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, movespeed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag=="Hit")
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, Spawnfuite.position, movespeed * Time.deltaTime);
    //    }
    //}
}
