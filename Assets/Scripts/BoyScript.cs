using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour{

    public enum EnemyState
    {
        WALK,
        ATTACK
    }

    [SerializeField] private GameObject snowballSpawn;

    [SerializeField] private GameObject boyAttackZone;

    [SerializeField] private float moveSpeed;

  //[SerializeField] private GameObject target;

    private float distance;
    [SerializeField] private float throwDistance;
    private bool isAttacking = false;
    private EnemyState enemyState = EnemyState.WALK;

    [SerializeField] private SpawnScript spawnScript;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private DropSystemScript dropSystem;

    private PlayerEnergyBar playerEnergy;
    private Transform playerTransform;
    [SerializeField] private int health;
    private int deadpoints = 100;

    // Use this for initialization
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerScript>().transform;
        gameManager = FindObjectOfType<GameManager>();
        playerEnergy = FindObjectOfType<PlayerEnergyBar>();
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

        if (distance <= throwDistance)
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
            playerEnergy.WinEnergy();
            gameManager.score = gameManager.score + deadpoints;
            dropSystem.calculateLoot();  
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnowballPlayer")
        {
            health = health - 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigSnowBall")
        {
            health = health - 2;
        }
    }
}