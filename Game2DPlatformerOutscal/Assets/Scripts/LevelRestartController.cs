using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestartController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Player has died and game has restarted");
        }
    }
}
