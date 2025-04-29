using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D boxCollider;
    private Vector2 originalSize;
    private Vector2 originalOffSet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        originalSize = boxCollider.size;
        originalOffSet = boxCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", isCrouching);

        if (isCrouching)
        {
            boxCollider.size = new Vector2(originalSize.x, originalSize.y / 2f);
            boxCollider.offset = new Vector2(originalOffSet.x, originalOffSet.y - 0.25f);
        }
        else
        {
            boxCollider.size = originalSize;
            boxCollider.offset = originalOffSet;
        }
        Debug.Log("Collider size: " + boxCollider.size);
    }
}
