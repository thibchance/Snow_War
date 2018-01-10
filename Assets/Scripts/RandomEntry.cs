using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEntry : MonoBehaviour {

    [SerializeField]
    GameObject dog;
    [SerializeField]
    GameObject ennemies;
    [SerializeField]
    Transform spawnentry;
    [SerializeField]
    Transform spawn1;
    float spawntime;
    float spawnPeriod = 3f;

    


   

    //private float mintime = 10;
    //private float maxtime = 40;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("ennemi(Clone)") == null)
        {


            spawntime += Time.deltaTime;
            if (spawntime >= spawnPeriod)
            {
                SpawnEntryRandom();
                Dog();
            }

        }

     
    }

    private void Dog()
    {
        Instantiate(dog, spawn1.position, spawn1.rotation);
        spawntime = 0;
    }
    private void SpawnEntryRandom()
    {

       
        
        
            Instantiate(ennemies, spawnentry.position, spawnentry.rotation);
            spawntime = 0;
        
        



    }
}
