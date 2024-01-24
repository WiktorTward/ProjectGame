using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyMovement : MonoBehaviour
{
    float Selection;

    [Space(10)]
    [Header("Start")]
    public GameObject StartSprite;
    public GameObject startedSelected;


    [Space(10)]
    [Header("Exit")]
    public GameObject ExitSprite;
    public GameObject ExitSelected;

    void Start()
    {
        Selection = 1;
    }

  
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Selection <= 2)
            {
                Selection++;
            }
            if (Selection > 2)
            {
                Selection = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Selection >= 1)
            {
                Selection--;
            }
            if (Selection < 1)
            {
                Selection = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Selection == 1)
            {
                PlayerPrefs.SetInt("score", 0);
                SceneManager.LoadScene(1);
            }
            else if (Selection == 2)
            {
                Application.Quit();
            }
        }


        if (Selection == 1)
        {
            StartSprite.SetActive(false);
            startedSelected.SetActive(true);
            ExitSprite.SetActive(true);
            ExitSelected.SetActive(false);
        }

        if (Selection == 2)
        {
            StartSprite.SetActive(true);
            startedSelected.SetActive(false);
            ExitSprite.SetActive(false);
            ExitSelected.SetActive(true);
        }
    }
}
