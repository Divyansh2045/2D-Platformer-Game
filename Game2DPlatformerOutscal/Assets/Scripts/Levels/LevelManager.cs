using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }


   // public string [] Levels;
    private string Level1 = "Level1";

    private void Awake()
    {
        if (Instance == null)
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
        if (getLevelStatus(Level1) == LevelStatus.Locked)
        {
            setLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelCompleted()
    {
        setLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);

        string nextSceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1);
        setLevelStatus(nextSceneName, LevelStatus.Unlocked);

        /* int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
         int nextSceneIndex = currentSceneIndex + 1;

         if (nextSceneIndex < Levels.Length)
         {
             setLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
         }
        */
    }
    private string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    public LevelStatus getLevelStatus(string levelName)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelName);
        return levelStatus;
    }

    public void setLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int)levelStatus);
    }


}
