using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;
    public int Score = 0;
    public int SceneScore = 0;
    public int Life;
    public int Life_init;

    private void Awake(){
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Life = Life_init;
    }

    private void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        SceneScore=0;
    }


    public static void AddScore(int added_score){
        MainManager.Instance.SceneScore += added_score;
    }

    public static void FinalizeScore(){
        MainManager.Instance.Score += MainManager.Instance.SceneScore;
    }

    public static void LoseLife(){
        MainManager.Instance.Life -= 1;
    }

    public static void AddLife(int added_life){
        MainManager.Instance.Life += added_life;
    }

    public static void Reset(){
        MainManager.Instance.Life = MainManager.Instance.Life_init;
        MainManager.Instance.Score = 0;
        MainManager.Instance.SceneScore = 0;
    }

}