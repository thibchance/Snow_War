using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DogScript : MonoBehaviour {




    //[Header("Velocity")]
    //[SerializeField]
    //float Velocity_X;
    //[SerializeField]
    //float Velocity_Y;


    [SerializeField]
    Transform Player;
    [SerializeField]
    float movespeed = 1f;
    // private Transform transform;



    Vector2 Destination;
    
    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.position, movespeed*Time.deltaTime);

        
           
	}
}
