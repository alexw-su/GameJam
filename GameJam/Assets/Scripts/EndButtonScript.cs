using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;

public class EndButtonScript : MonoBehaviour
{
    public UnityEvent interactEvent;
    //on trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON COLLISION");
        if (other.gameObject.CompareTag("Moth"))
        {
            interactEvent?.Invoke();

            //LevelManager.instance.LevelCompleted();
        }
    }
}
