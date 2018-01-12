using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{

    public enum EnemyState
    {
        WALK,
        ATTACK
    }

    [SerializeField] private GameObject snowballSpawn;
    [SerializeField] private GameObject boyAttackZone;
    [SerializeField] private float moveSpeed;
  //  [SerializeField] private GameObject target;
    private float distance;

    private bool isAttacking = false;

    private EnemyState enemyState = EnemyState.WALK;

    [SerializeField] private SpawnScript spawnScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DropSystemScript dropSystem;


    [SerializeField] GameObject[] CoinBonus;
    
    private Transform playerTransform;
    private int health = 3;
    private int deadpoints = 100;

    // Use this for initialization
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
       
        distance = Vector2.Distance(transform.position, playerTransform.transform.position);
        //Debug.Log("Distance" + distance);

        if (distance <= 5.00)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        //Debug.Log("is Attacking " + isAttacking);

        if (isAttacking)
        {
            enemyState = EnemyState.ATTACK;
        }
        else
        {
            enemyState = EnemyState.WALK;
        }

        switch (enemyState)
        {
            case EnemyState.WALK:
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.transform.position, moveSpeed * Time.deltaTime);
                break;
            case EnemyState.ATTACK:
                spawnScript.Attack();
                break;
        }

        
       
        if (health <= 0)
        {
            
            Destroy(gameObject);
            gameManager.score = gameManager.score + deadpoints;
           // CoinsRandom();
            dropSystem.calculateLoot();

           
            
           
        }

    }

    
   private void CoinsRandom()
    {
        int Coins = Random.Range(0, 2);
        
        
       Instantiate(CoinBonus[Coins], transform.position, transform.rotation);
        
       
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnowballPlayer")
        {
            health = health - 1;
        }

        
    }

}