using UnityEngine;
using System.Collections;
using System;

public class NPCController : MonoBehaviour
{
    public float Speed;
    public Transform[] Waypoints_Morning;
    public Transform[] Waypoints_Afternoon;
    public Transform[] Waypoints_Evening;

    private Transform[] Waypoints_Current;
    private int currentWaypointIndex;
    private Rigidbody2D npcRigidbody2D;
    private Animator animator;
    private Vector3 directionChange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        npcRigidbody2D = GetComponent<Rigidbody2D>();
        Waypoints_Current = Array.Empty<Transform>();
        StartCoroutine(Coroutine_SetWayPoints());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWaypointIndex < Waypoints_Current.Length)
        {
            animator.SetBool("isMoving", true);
            MoveNPC();
        } else
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("moveY", -1);
        }
    }

    void MoveNPC()
    {
        var directionChange = (Vector2)(Waypoints_Current[currentWaypointIndex].position - transform.position);
        animator.SetFloat("moveX", directionChange.x);
        animator.SetFloat("moveY", directionChange.y);

        transform.position = Vector2.MoveTowards(
            transform.position, 
            Waypoints_Current[currentWaypointIndex].position, 
            Speed * Time.deltaTime
        );

        if((Vector2)transform.position == (Vector2)Waypoints_Current[currentWaypointIndex].position)
        {
            currentWaypointIndex++;
        }
    }

    IEnumerator Coroutine_SetWayPoints()
    {
        yield return new WaitForSeconds(3f);

        currentWaypointIndex = 0;
        Waypoints_Current = Waypoints_Morning;

        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => !animator.GetBool("isMoving"));
        yield return new WaitForSeconds(3f);

        currentWaypointIndex = 0;
        Waypoints_Current = Waypoints_Afternoon;
    }
}
