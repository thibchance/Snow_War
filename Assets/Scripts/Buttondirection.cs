using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttondirection : MonoBehaviour {
     public void LoadIndex (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

	
