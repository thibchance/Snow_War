using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] float speed;

    private Rigidbody2D body;


    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed,
                                       moveVertical * speed);

        body.velocity = movement;
    }
}
