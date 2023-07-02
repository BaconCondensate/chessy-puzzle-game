using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   // [SerializeField] private string newGameLevel = "level1";
    // Start is called before the first frame update
    public void NewGameButton(){
        MainManager.Reset();
        SceneManager.LoadScene("StartMenu");
    }
    

    public void NextLevel(){
        MainManager.FinalizeScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RetryLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
