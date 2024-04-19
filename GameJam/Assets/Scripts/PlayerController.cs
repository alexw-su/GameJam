using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Debug.Log("mouse pos" + mousePos);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;

        // Convert the screen coordinates to world coordinates
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction vector from the player to the mouse position
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        moveDirection.y = 0;
        // Move the player towards the mouse position
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}
