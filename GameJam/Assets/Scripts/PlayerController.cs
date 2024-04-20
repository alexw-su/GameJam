using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{


    PlayerActions input;
    NavMeshAgent agent;
    [Header("Movement")]
    [SerializeField] LayerMask clickableLayers;
    public float lookRotationSpeed = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        input = new PlayerActions();
        AssignInputs();
    }
    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }
    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
        }
    }
    void OnEnable()
    {
        input.Enable();
    }
    void OnDisable()
    {
        input.Disable();
    }
    //public float moveSpeed = 5f;
    //private Vector3 lastTarget;
    //public float stopDistance = 0.3f;
    //void Update()
    //{
    //    if (MenuManager.instance.IsGameStarted() && Input.GetMouseButtonDown(0))
    //    {
    //        // Create a ray from the camera to the point clicked by the mouse
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        // Perform the raycast
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            // Get the point where the ray hit the ground (or any other collider)
    //            lastTarget = hit.point;
    //        }
    //    }

    //    // Ignore the y-component of the lastTarget and keep the player's y-coordinate unchanged
    //    Vector3 targetPosition = lastTarget;
    //    targetPosition.y = transform.position.y;

    //    // Calculate the direction vector from the player to the target position
    //    Vector3 moveDirection = (targetPosition - transform.position).normalized;

    //    // Calculate the distance between the player and the target position
    //    float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

    //    // Move the player towards the target position if the distance is above the stopDistance threshold
    //    if (distanceToTarget > stopDistance)
    //    {
    //        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    //    }
    //}
}


