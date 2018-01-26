using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    int Credits = 100;

    bool startSpawn = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RandomEnemy()
    {
        int EnemySpawnchance = Random.Range(0, 101);

        if(Credits <= 0)
        {
            startSpawn = false;
        }

        if(EnemySpawnchance<=70)
        {
            Debug.Log("Boy I Choose you !");
            Credits = Credits - 10;
        }
        else
        {
            Debug.Log("Dog I Choose you !");
            Credits = Credits - 5;
        }
    }
}
