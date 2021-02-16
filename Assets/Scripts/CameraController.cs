using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float Lerp;
    public Vector2 MinPosition;
    public Vector2 MaxPosition;

    [NonSerialized]
    public Vector2 DefaultMinPosition, DefaultMaxPosition;

    // Start is called before the first frame update
    void Start()
    {
        DefaultMinPosition = MinPosition;
        DefaultMaxPosition = MaxPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != Target.position)
        {
            Vector3 targetPos = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, MinPosition.x, MaxPosition.x);
            targetPos.y = Mathf.Clamp(targetPos.y, MinPosition.y, MaxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPos, Lerp);
        }
    }
}
