using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
   
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
    }

    public void playerDied()
    {
        SoundManager.Instance.Play(SoundTypes.PlayerDeath);
        gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
       Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Debug.Log("Player has died and game has restarted");
        SoundManager.Instance.Play(SoundTypes.ButtonClick);
    }
}
