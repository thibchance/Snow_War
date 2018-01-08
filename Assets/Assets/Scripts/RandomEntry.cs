using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEntry : MonoBehaviour {


    [SerializeField]
    GameObject[] ennemies;
    [SerializeField]
    Transform[] spawnentry;
	// Use this for initialization
	void Start ()
    {
        SpawnEntryRandom();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void SpawnEntryRandom()
    {
        int spawnindex = Random.Range(0, spawnentry.Length);
        int ennemisindex = Random.Range(0, ennemies.Length);

        for (int i = 0; i < spawnentry.Length; i++)
        {
            Instantiate(ennemies[ennemisindex], spawnentry[i].position, spawnentry[0].rotation);
        }

    }
}
