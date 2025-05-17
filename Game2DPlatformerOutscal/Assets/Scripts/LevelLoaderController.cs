using System;
using UnityEngine;
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
        SceneManager.LoadScene(levelName);
    }
}
