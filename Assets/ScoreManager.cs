using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    }

    public void AddPoint()
    {
        score +=1;
        scoreText.text = score.ToString() + " : POINTS";
        if (hiscore<score)
            PlayerPrefs.SetInt("hiscore", score);
    }
}