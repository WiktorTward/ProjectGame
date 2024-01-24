using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCKeyMovement : MonoBehaviour
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

    public Canvas uiCanvas;

    private bool isKeyMovementEnabled = false;
    private bool isCanvasActive = false;

    void Start()
    {
        Selection = 1;
        uiCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isKeyMovementEnabled = !isKeyMovementEnabled;
            Selection = 1;

            if (isKeyMovementEnabled)
            {
                if (!isCanvasActive)
                {
                    ActivateCanvas();
                }
            }
            else
            {
                if (isCanvasActive)
                {
                    DeactivateCanvas();
                }
            }
        }

        if (isKeyMovementEnabled)
        {
            HandleKeyMovement();
        }
    }

    void ActivateCanvas()
    {
        uiCanvas.gameObject.SetActive(true);
        isCanvasActive = true;
    }

    void DeactivateCanvas()
    {
        uiCanvas.gameObject.SetActive(false);
        isCanvasActive = false;
    }

    void HandleKeyMovement()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSelection(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeSelection(-1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleSpaceKey();
        }
    }

    void ChangeSelection(int direction)
    {
        Selection += direction;
        Selection = Mathf.Clamp(Selection, 1, 2);
        UpdateSelectionUI();
    }

    void HandleSpaceKey()
    {
        if (Selection == 1)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else if (Selection == 2)
        {
            Application.Quit();
        }
    }

    void UpdateSelectionUI()
    {
        if (Selection == 1)
        {
            StartSprite.SetActive(false);
            startedSelected.SetActive(true);
            ExitSprite.SetActive(true);
            ExitSelected.SetActive(false);
        }
        else if (Selection == 2)
        {
            StartSprite.SetActive(true);
            startedSelected.SetActive(false);
            ExitSprite.SetActive(false);
            ExitSelected.SetActive(true);
        }
    }
}
