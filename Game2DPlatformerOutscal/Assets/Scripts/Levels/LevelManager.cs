using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  private static LevelManager instance;
  public static LevelManager Instance;

    public string [] Levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (getLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            setLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Instance.setLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < Levels.Length)
        {
            setLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }

    }

    public LevelStatus getLevelStatus(string levelName)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelName);
        return levelStatus;
    }

    public void setLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.GetInt(levelName, (int)levelStatus);
    }


}
