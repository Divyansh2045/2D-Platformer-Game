using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestartController : MonoBehaviour
{
    public GameOverController gameOverController;

    public IEnumerator levelRestartCouroutine()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverController.playerDied();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Player has died and game has restarted");
            SoundManager.Instance.Play(SoundTypes.LevelComplete);
            StartCoroutine(levelRestartCouroutine());
        }
    }
}
