using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
  public LevelCompleteScreen levelCompleteScreen;

    public IEnumerator levelOverCouroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (levelCompleteScreen != null)
        {
            levelCompleteScreen.levelComplete();
            Debug.Log("Level over trigger is happening and the code reaches this point");


        }
        else
        {
            Debug.LogError("LevelCompleteScreen is not assigned in the inspector!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (collision.GetComponent<PlayerController>() !=null)
        {
            Debug.Log("Level is over");
            LevelManager.Instance.MarkCurrentLevelCompleted();
            StartCoroutine(levelOverCouroutine());
            playerController.disablePlayer();
            // int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //SceneManager.LoadScene(nextSceneIndex);

        }
    }

}
