using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] LayerMask platformLayerMask;
    private Vector2 boxColOriginalSize;
    private Vector2 boxColOriginalOffSet;
    public float speed;
    public float jump;
    private Rigidbody2D rb2D;
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public HealthUI healthUI;
    public int health;
    private bool canDoubleJump;

    private void Awake()
    {
        Console.WriteLine("Player controller Awake");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxColOriginalSize = boxCollider.size;
        boxColOriginalOffSet = boxCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");

        playMovementAnimation(horizontal, vertical);
        moveCharacter(horizontal, vertical);
       


        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch(true);
        }
        else
        {
            crouch(false);
        }
    }

    private void moveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;

        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        // PLAY RUN SOUND ONLY WHEN MOVING & GROUNDED
        if (Mathf.Abs(horizontal) > 0.1f && IsGrounded())
        {
            SoundManager.Instance.PlayRunLoop();
        }
        else
        {
            SoundManager.Instance.StopRunLoop();
        }

        if (IsGrounded())
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                // First jump using velocity
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jump);
                playerAnimator.SetTrigger("Jump");
                SoundManager.Instance.Play(SoundTypes.PlayerJump);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                // Double jump using velocity
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jump);
                playerAnimator.SetTrigger("Jump");
                SoundManager.Instance.Play(SoundTypes.PlayerJump);
                canDoubleJump = false;
            }
        }


    }
    private void playMovementAnimation(float horizontal, float vertical)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
        playerAnimator.SetFloat("vSpeed", rb2D.linearVelocity.y);
        playerAnimator.SetBool("isGrounded", IsGrounded());
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

    }
    public void crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offsetX = -0.566f;
            float offsetY = 0.61224f;

            float sizeX = 0.84055f;
            float sizeY = 1.34307f;

            boxCollider.offset = new Vector2(offsetX, offsetY);
            boxCollider.size = new Vector2(sizeX, sizeY);

        }
        else
        {
            boxCollider.offset = boxColOriginalOffSet;
            boxCollider.size = boxColOriginalSize;
        }

        playerAnimator.SetBool("Crouch", crouch);

    }
    
    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        Color rayColor;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider.bounds.center + new Vector3 (boxCollider.bounds.extents.x,0), Vector3.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector3.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeight), Vector3.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);


        return raycastHit.collider != null;

                                
    }

    public void pickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncrementScore(10);
        SoundManager.Instance.Play(SoundTypes.KeyCollect);
        SoundManager.Instance.SetVolume(1f);
    }

    public IEnumerator gameOverCouroutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverController.playerDied();
        disablePlayer();
        Destroy(gameObject);
    }

   public void KillPlayer()
    {
            Debug.Log("Player has died");
            playDeathAnimation();
        SoundManager.Instance.Play(SoundTypes.PlayerDeath);
        StartCoroutine(gameOverCouroutine());
        

    }
    public void disablePlayer()
    {
        this.enabled = false;
    }

    public void playDeathAnimation()
    {
        playerAnimator.SetTrigger("Death");
       // GetComponent<PlayerMovement>().enabled = false;
    }

     public void reduceHealth()
    {
        health --;
        if (healthUI != null)
        {
            healthUI.UpdateHearts(health); // Animate the heart corresponding to the lost health
        }

        if (health <= 0)
        {
            KillPlayer();
        }
    }

}
