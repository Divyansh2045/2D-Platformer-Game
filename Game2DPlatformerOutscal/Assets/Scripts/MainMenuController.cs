using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public GameObject levelSelection;
    public Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

  

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

    private void PlayGame()
    {
       Scene scene = SceneManager.GetActiveScene();
        levelSelection.SetActive(true);
    }


}
