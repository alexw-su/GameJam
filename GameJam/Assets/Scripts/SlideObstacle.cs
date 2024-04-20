using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideObstacle : MonoBehaviour
{
    [SerializeField] Vector3 moveDestination;
    [SerializeField] float movementSpeed = 1f;
    private bool hasMoved = false;

    public void MoveObstacle()
    {
        if (!hasMoved)
        {
            hasMoved = true;
            StartCoroutine(MoveToDestination());

        }
    }

    IEnumerator MoveToDestination()
    {
        Vector3 initialPosition = transform.position;
        float journeyLength = Vector3.Distance(initialPosition, moveDestination);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, moveDestination) > 0.01f)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, moveDestination, fractionOfJourney);
            yield return null;
        }

        // Ensure it reaches exactly to destination
        transform.position = moveDestination;
    }
}
