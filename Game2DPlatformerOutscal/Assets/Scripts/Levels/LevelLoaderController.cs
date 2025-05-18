using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoaderController : MonoBehaviour
{
    public string levelName;
    private Button levelButton;

    private void Awake()
    {
     levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.getLevelStatus(levelName);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant play this level until its unlocked");
                break;

            case LevelStatus.Unlocked:
                break;

            case LevelStatus.Completed:
                break;
               
        }
        SceneManager.LoadScene(levelName);
    }
}
