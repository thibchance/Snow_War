using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;

    [SerializeField]
    public Text textscore;
    private const string TEXT_SCORE = " ";

    int Ennemie = 0;
   
    // Use this for initialization
    void Start ()
    {
        textscore.text = TEXT_SCORE + score;
        textscore.text = PlayerPrefs.GetInt("Score", 0).ToString();
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("score" + score);
        textscore.text = TEXT_SCORE + score;
        if(Ennemie == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        //if (Ennemie == -1 || GameObject.Find("Boss").GetComponent<BossScript>().GetHEALTH()==0)
        //{
           
        //}
        
    }

    public void Dieboy()
    {
        Ennemie--;
    }
    public void Apparait()
    {
        Ennemie++;
    }
}
