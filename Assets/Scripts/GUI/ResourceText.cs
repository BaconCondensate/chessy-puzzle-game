using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResourceText : MonoBehaviour
{
    //public static ResourceText Instance;
    public TMP_Text uiLife;
    public TMP_Text uiScore;
    private int totalScore = 0;
    private int totalLife = 0;

    void Update(){
        //clockText.text = DateTime.Now.ToString();
        totalScore = MainManager.Instance.Score + MainManager.Instance.SceneScore;
        if (totalScore != null){
            uiScore.text = totalScore.ToString();
        }
        
        totalLife = MainManager.Instance.Life;
        if (totalLife != null){
            uiLife.text = totalLife.ToString();
        }
        
    }
}
