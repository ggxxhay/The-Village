using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Vector2 NewMinPosition;
    public Vector2 NewMaxPosition;
    public Vector3 NewPlayerPosition;
    public Transform PlayerTransform;
    public bool IsMovingUp;

    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((IsMovingUp && Input.GetAxisRaw("Vertical") > 0))
            {
                cameraController.MinPosition = NewMinPosition;
                cameraController.MaxPosition = NewMaxPosition;
                PlayerTransform.position = NewPlayerPosition;
            } 
            else if (!IsMovingUp && Input.GetAxisRaw("Vertical") < 0)
            {
                cameraController.MinPosition = cameraController.DefaultMinPosition;
                cameraController.MaxPosition = cameraController.DefaultMaxPosition;
                PlayerTransform.position = NewPlayerPosition;
            }
        }
    }
}
