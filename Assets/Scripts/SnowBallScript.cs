using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScript : MonoBehaviour {

    enum SnowBallType
    {
        SNOWBALL,
        DOUBLESNOWBALL,
        BIGSNOWBALL,
        SNOWWAVE

    }
    [SerializeField] GameObject bullet;

    [SerializeField] GameObject BulletPosition;

    [SerializeField] float speed;

    [SerializeField] Transform Bulletspawn;

    [SerializeField] float snowballSpeed;

    [SerializeField] float timeToThrow = 2;

    [SerializeField] float lastTimeThrow;

    private SnowBallType snowballtype;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (snowballtype)
        {
            case SnowBallType.SNOWBALL:
                if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
                {
                    GameObject Snowball = Instantiate(bullet, Bulletspawn.position, Bulletspawn.rotation);
                    Snowball.GetComponent<Rigidbody2D>().velocity = Bulletspawn.right * snowballSpeed;
                    Destroy(Snowball, 5);
                    lastTimeThrow = Time.realtimeSinceStartup;
                }
                break;
            case SnowBallType.DOUBLESNOWBALL:
                break;

            case SnowBallType.BIGSNOWBALL:
                break;
            case SnowBallType.SNOWWAVE:
                break;

        }
    }
}
