using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float Speed;
    public Transform[] Waypoints;

    private int currentWaypointIndex;
    private Rigidbody2D npcRigidbody2D;
    private Animator animator;
    private Vector3 directionChange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        npcRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWaypointIndex < Waypoints.Length)
        {
            animator.SetBool("isMoving", true);
            MoveNPC();
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void MoveNPC()
    {
        var directionChange = (Vector2)(Waypoints[currentWaypointIndex].position - transform.position);
        animator.SetFloat("moveX", directionChange.x);
        animator.SetFloat("moveY", directionChange.y);

        transform.position = Vector2.MoveTowards(
            transform.position, 
            Waypoints[currentWaypointIndex].position, 
            Speed * Time.deltaTime
        );

        if((Vector2)transform.position == (Vector2)Waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex++;
        }
    }
}
