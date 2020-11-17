using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody2D;
    private Animator animator;
    private Vector3 directionChange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        directionChange = Vector3.zero;
        directionChange.x = Input.GetAxisRaw("Horizontal");
        directionChange.y = Input.GetAxisRaw("Vertical");
        if (directionChange != Vector3.zero)
        {
            MovePlayer();
            animator.SetFloat("moveX", directionChange.x);
            animator.SetFloat("moveY", directionChange.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void MovePlayer()
    {
        playerRigidbody2D.MovePosition(transform.position + directionChange * Speed * Time.deltaTime);
    }
}
