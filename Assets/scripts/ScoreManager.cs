using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highsoreText;

    int score = 0;
    int hiscore = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
        score = PlayerPrefs.GetInt("score");
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        scoreText.text = score.ToString() + " : POINTS";
        highsoreText.text = "HIGHSCORE : " + hiscore.ToString();

    }

    public void AddPoint()
    {
        score +=1;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString() + " : POINTS";
        if (hiscore<score)
            PlayerPrefs.SetInt("hiscore", score);


        if (score == 15)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_2");
        }

        if (score == 30)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_3");
        }
        if(score == 40)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("Menu");
        }
    }
}