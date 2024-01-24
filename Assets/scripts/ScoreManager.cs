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
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        scoreText.text = score.ToString() + " : POINTS";
        highsoreText.text = "HIGHSCORE : " + hiscore.ToString();
        if (score == 3)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_2");
        }
        if (score == 30)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_3");
        }
    }

    public void AddPoint()
    {
        score +=1;
        scoreText.text = score.ToString() + " : POINTS";
        if (hiscore<score)
            PlayerPrefs.SetInt("hiscore", score);
        if (score == 5)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_2");
        }
        if (score == 8)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("LVL_3");
        }
    }
}