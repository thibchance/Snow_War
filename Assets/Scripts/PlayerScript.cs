using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject BulletPosition;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform Bulletspawn;
    [SerializeField]
    float snowballSpeed;
    [SerializeField]
    float timeToThrow = 2;
    [SerializeField]
    float lastTimeThrow;
    private Rigidbody2D body;


    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //// if (Input.GetButtonDown("Fire1"))
        // {
        //     GameObject bullet01 = (GameObject)Instantiate(bullet);
        //     bullet01.transform.position = BulletPosition.transform.position;

        //     Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;


        // }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if(Physics.Raycast(ray))
        //{
        //    Debug.Log("souris");
        //    Instantiate(bullet, transform.position, transform.rotation);
        //}
        //Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //rotation.z = 10;
        //Bullet.position = rotation;
        
        
        
        Bulletspawn.rotation = Quaternion.LookRotation(Vector3.forward, Bulletspawn.position);
        Attack();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal*speed,
                                      moveVertical*speed);
        //Event e = Event.current;
        //Vector2 mousePos = new Vector2();

        //Move(direction);
        body.velocity = movement;
    }
    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)

        {
            GameObject Snowball = Instantiate(bullet, Bulletspawn.position, Bulletspawn.rotation);

            Snowball.GetComponent<Rigidbody2D>().velocity = Bulletspawn.right * snowballSpeed;
            Destroy(Snowball, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }
    private  void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x = min.x + 0.225f;
        max.x = max.x + 0.225f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
