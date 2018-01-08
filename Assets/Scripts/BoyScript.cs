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
    [SerializeField] private GameObject target;
    private float distance;

    private bool isAttacking = false;

    private EnemyState enemyState = EnemyState.WALK;

    [SerializeField] private SpawnScript spawnScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
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
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                break;
            case EnemyState.ATTACK:
                spawnScript.Attack();
                break;
        }

    }

}