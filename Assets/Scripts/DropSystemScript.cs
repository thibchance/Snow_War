using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystemScript : MonoBehaviour
{
    [SerializeField] GameObject CoinBonus;

    [SerializeField] GameObject bonusAttack;

    int coins;

    public void calculateLoot()
    {
        int calcDropchance = Random.Range(0, 101);

        if (calcDropchance <= 50)
        {
           
            return;
        }

        if(calcDropchance > 50 && calcDropchance <= 75)
        {
           
            Instantiate(CoinBonus, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }

        if(calcDropchance > 75)
        {
            
            Instantiate(bonusAttack, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}
