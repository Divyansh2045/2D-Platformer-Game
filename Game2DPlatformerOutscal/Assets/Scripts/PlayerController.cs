using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCollider;
    private Vector2 boxColOriginalSize;
    private Vector2 boxColOriginalOffSet;
    public float speed;
    public float jump;
    private Rigidbody2D rb2D;

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

       

       // playJumpAnimation(VerticalInput);

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

        if (vertical > 0)
        {
            rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }


    }
    private void playMovementAnimation(float horizontal, float vertical)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
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

        if (vertical > 0)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
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
   // public void playJumpAnimation(float vertical)
   // {
   //     if (vertical > 0)
    //    {
   //         playerAnimator.SetTrigger("Jump");
 //       }
  //  }

    


}
