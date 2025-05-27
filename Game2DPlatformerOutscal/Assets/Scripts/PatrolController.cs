/*using System;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PatrolController : MonoBehaviour
{
    public float speed;
    public Transform groundCheck;
    public Transform wallCheck;
    private int direction = 1; // 1 = right, -1 = left
    private Rigidbody2D rb;
    private bool movingRight = true;
    private float raycastLength = .1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
      

    }

    private bool isHittingWall()
    {
        Color rayColor;
        RaycastHit2D wallRay = Physics2D.Raycast(wallCheck.position, Vector2.right, raycastLength);
       
        if (wallRay.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(wallCheck.position, Vector2.right * raycastLength, rayColor);
        return wallRay.collider != null;

    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = rb.linearVelocity;
        currentVelocity.x = speed * direction;
        rb.linearVelocity = currentVelocity;

        if (IsGrounded() || isHittingWall())
        {
            Flip();
        }
    }

    private bool IsGrounded()
    {
        Color rayColor;
        RaycastHit2D groundRay = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastLength);

        if (groundRay.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(groundCheck.position, Vector2.down * raycastLength, rayColor);
        return groundRay.collider != null;
    }

    public void Flip()
    {
        direction *= -1;
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingRight = true;
        }
    }
}
*/
