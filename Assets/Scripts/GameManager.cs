using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;

    [SerializeField]
    public Text textScore;
    private const string TEXT_SCORE = " ";

    int Ennemie = 0;
    int level = 0;
    // Use this for initialization
    void Start ()
    {
        textScore.text = TEXT_SCORE + score;
        textScore.text = PlayerPrefs.GetInt("Score", 0).ToString();
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("score" + score);
        textScore.text = TEXT_SCORE + score;
        if(level < 4)
        {
            NextLevel();
            
        }
       

    }
    private void NextLevel()
    {
        if (Ennemie == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            level++;
        }
    }
    public void FinalLevel()
    {
       
        
            SceneManager.LoadScene("VictoryMenu");
        
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
