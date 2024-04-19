using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 lastTarget;
    public float stopDistance = 0.3f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the point clicked by the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Get the point where the ray hit the ground (or any other collider)
                lastTarget = hit.point;
            }
        }

        // Ignore the y-component of the lastTarget and keep the player's y-coordinate unchanged
        Vector3 targetPosition = lastTarget;
        targetPosition.y = transform.position.y;

        // Calculate the direction vector from the player to the target position
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Calculate the distance between the player and the target position
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // Move the player towards the target position if the distance is above the stopDistance threshold
        if (distanceToTarget > stopDistance)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
// Update is called once per frame
//void Update()
//{
//    Vector3 mousePos = Input.mousePosition;
//    Debug.Log("mouse pos" + mousePos);

//    Vector3 mousePosition = Input.mousePosition;
//    mousePosition.z = 10;

//    // Convert the screen coordinates to world coordinates
//    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

//    // Calculate the direction vector from the player to the mouse position
//    Vector3 moveDirection = (targetPosition - transform.position).normalized;

//    moveDirection.y = 0;
//    // Move the player towards the mouse position
//    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
//}

