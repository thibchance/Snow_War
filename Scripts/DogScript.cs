﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DogScript : MonoBehaviour
{


    
    [SerializeField] float movespeed = 1f;

    [SerializeField] GameManager gameManager;
    private Transform playerTransform;

    //Vector2 Destination;

    private int health = 2;
    private int deadpoints = 50;
    
    // Use this for initialization
    void Start ()
    {
        playerTransform = FindObjectOfType<PlayerScript>().transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, movespeed*Time.deltaTime);

        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.score = gameManager.score + deadpoints;
        }
        
           
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnowballPlayer")
        {
            health = health - 1;
        }
    }
}
