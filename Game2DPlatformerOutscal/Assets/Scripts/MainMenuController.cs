using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    public GameObject levelSelection;
    [SerializeField] private Button quitButton;

    private void Awake()
    { 
     
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

  

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is closed");
        SoundManager.Instance.Play(SoundTypes.BackButton);
    }

    private void PlayGame()
    {
      SoundManager.Instance.Play(SoundTypes.GameStart);   
        levelSelection.SetActive(true);
    }


}
