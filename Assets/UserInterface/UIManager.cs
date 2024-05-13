using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    public GameObject gameOverMenu;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        HideGameOverMenu();
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void HideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

}