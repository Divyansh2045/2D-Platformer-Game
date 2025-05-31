using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
  public LevelCompleteScreen levelCompleteScreen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (collision.GetComponent<PlayerController>() !=null)
        {
            Debug.Log("Level is over");
            LevelManager.Instance.MarkCurrentLevelCompleted();
            
            playerController.disablePlayer();
            // int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (levelCompleteScreen != null)
            {
                levelCompleteScreen.levelComplete();
                Debug.Log("Level over trigger is happening and the code reaches this point");
               
                
            }
            else
            {
                Debug.LogError("LevelCompleteScreen is not assigned in the inspector!");
            }
            



            //SceneManager.LoadScene(nextSceneIndex);

        }
    }

}
