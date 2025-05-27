using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestartController : MonoBehaviour
{
    public GameOverController gameOverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Player has died and game has restarted");
            SoundManager.Instance.Play(SoundTypes.LevelComplete);
            if (gameOverController != null)
            {
                gameOverController.playerDied();


            }
            else
            {
                Debug.LogError("LevelCompleteScreen is not assigned in the inspector!");
            }
        }
    }
}
