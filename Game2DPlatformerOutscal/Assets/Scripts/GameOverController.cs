using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMainMenu;
   
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
        buttonMainMenu.onClick.AddListener(LoadMainMenu);
    }

    public void playerDied()
    {
        
        gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
       Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Debug.Log("Player has died and game has restarted");
        SoundManager.Instance.Play(SoundTypes.ButtonClick);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance.Play(SoundTypes.ButtonClick);
    }
}
