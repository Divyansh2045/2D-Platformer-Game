using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteScreen : MonoBehaviour
{
    public Button levelSelectionButton;
    public Button MainMenuButton;
  // public MainMenuController mainMenuController;

    private void Awake()
    {
        levelSelectionButton.onClick.AddListener(NextLevel);
        MainMenuButton.onClick.AddListener(OpenMainMenu);

    }
    private void NextLevel()
    {
        /*if (mainMenuController != null && mainMenuController.levelSelection != null)
        {
            mainMenuController.levelSelection.SetActive(true);
        }
        else
        {
            Debug.LogError("MainMenuController or levelSelection is not assigned.");
        } */

        // SceneManager.LoadScene("MainMenu");
        SoundManager.Instance.Play(SoundTypes.ButtonClick);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Game has been completed! Congratulations");
        }
    }

    private void OpenMainMenu()
    {
        SoundManager.Instance.Play(SoundTypes.ButtonClick);
        SceneManager.LoadScene("MainMenu"); // Replace with your actual scene name if needed
    }

    public void levelComplete()
    {
        SoundManager.Instance.Play(SoundTypes.LevelComplete);
        Debug.Log("Level complete function is getting called");
        gameObject.SetActive(true);
    }

   
}
