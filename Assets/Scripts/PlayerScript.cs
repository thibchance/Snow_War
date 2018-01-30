using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{

    [SerializeField] GameObject bullet;

    [SerializeField] GameObject BulletPosition;

    [SerializeField] float speed;

    [SerializeField] Transform Bulletspawn;

    [SerializeField] float snowballSpeed;

    [SerializeField] float timeToThrow = 2;

    [SerializeField] float lastTimeThrow;

    private Rigidbody2D body;
    private float timeLeft = 20f;
    private int ScoreCoins = 100;
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private bool startTimer = false;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);

        if(startTimer)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("Chrono" + timeLeft);

            if (timeLeft < 0)
            {
                timeToThrow = 2;
                startTimer = false;
                timeLeft = 20f;
            }
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BigSnowBall")
        {
           // bullet.GetComponent<Collider2D>().enabled = false;
           // voir avec nico pour changer la bullet 
            startTimer = true ;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "DoubleSnowball")
        {
            timeToThrow /= 2;
            startTimer = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SnowballEnemy") 
        {
            playerHealth.LoseLife();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Dog")
        {
            playerHealth.LoseLife();
        }

        if (collision.gameObject.tag == "ScoreCoin")
        {
            gameManager.score = gameManager.score + ScoreCoins;
            Destroy(collision.gameObject);
        }


    }
}
