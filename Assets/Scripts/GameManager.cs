using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;

    [SerializeField]
    Text textscore;
    private const string TEXT_SCORE = " ";

    // Use this for initialization
    void Start ()
    {
        textscore.text = TEXT_SCORE + score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("score" + score);
        textscore.text = TEXT_SCORE + score;
    }
}
