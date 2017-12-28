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

    private bool isAttacking = false;

    private EnemyState enemyState = EnemyState.WALK;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        
        switch (enemyState)
        {
            case EnemyState.WALK:
                break;
            case EnemyState.ATTACK:
                break;
        }

	}
}
