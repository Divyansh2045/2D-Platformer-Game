using System;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private float rayDistance;
    [SerializeField] private Transform wallDetector;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private ParticleController playerdead;

    private int direction = 1; // 1 = right, -1 = left

    void Update()
    {
        patrolEnemy();
        playMovementAnimation();
    }

    private void patrolEnemy()
    {
       // enemyAnimator.SetBool("IsPatrol", true);
        
        if(!IsGrounded() || IsHittingWall())
        {
            flipEnemy();
        }

        moveEnemy();

        if ((IsGrounded()))
        {
            SoundManager.Instance.PlayEnemyLoop();
        }
        else
        {
            SoundManager.Instance.StopEnemyLoop();
        }
    }

    private bool IsGrounded()
    {
        Color rayColor;
        RaycastHit2D groundHit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance, wallLayerMask);
        if (groundHit.collider == null)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green;
        }
            Debug.DrawRay(groundDetector.position, Vector2.down * rayDistance, rayColor);
        return groundHit.collider != null;
    }

    private bool IsHittingWall()
    {
        Color rayColor;
        RaycastHit2D wallHit = Physics2D.Raycast(wallDetector.position, Vector2.right * direction, rayDistance, wallLayerMask);
       
        //RaycastHit2D wallHit = Physics2D.Raycast(wallDetector.transform.position, Vector2.right, rayDistance);
        if (wallHit.collider == null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
       // Debug.DrawRay(wallDetector.position, Vector2.right * rayDistance, rayColor);
        Debug.DrawRay(wallDetector.position, Vector2.right * direction * rayDistance, rayColor);
        return wallHit.collider != null;    
    }

    private void moveEnemy()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
      
    }
    private void flipEnemy()
    {
        Vector3 scaleVector = transform.localScale;
        scaleVector.x *= -1;
        transform.localScale = scaleVector;
        direction *= -1;
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
  /  {
   /     if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.reduceHealth();
        }
    } */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.reduceHealth();
            Debug.Log(" ENemy with Player Tigger took place");
            enemyAnimator.SetTrigger("Attack");
            SoundManager.Instance.Play(SoundTypes.ChomperAttack);
            playerdead.PlayEffect();
            Debug.Log("Particle is getting spawned");

        }
    }

    private void playMovementAnimation()
    {
        enemyAnimator.SetFloat("Speed", moveSpeed);
    }

    private void OnDisable()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopEnemyLoop();
        }
    }

}
