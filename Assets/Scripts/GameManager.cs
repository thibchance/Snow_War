using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;

    [SerializeField]
    Text textscore;
    private const string TEXT_SCORE = " ";

    int Ennemie = 100;
    int boy = 10;
    int bigBrother = 10;
    int bigBoy = 10;
    int dog = 5;
    // Use this for initialization
    void Start ()
    {
        textscore.text = TEXT_SCORE + score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("score" + score);
        textscore.text = TEXT_SCORE + score;

        if (Ennemie < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    public void Dieboy()
    {
        Ennemie = Ennemie - boy;
    }
    public void Dieanimal()
    {
        Ennemie = Ennemie - dog;
    }
}
